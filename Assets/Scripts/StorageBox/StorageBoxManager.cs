using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;

/// <summary>
/// This class is to manage the storage box system
/// </summary>
public class StorageBoxManager : MonoBehaviour
{
    public static StorageBoxManager _instance;
    public static StorageBoxManager Instance { get { return _instance; } }

    public Dictionary<string, Item> ItemList = new Dictionary<string, Item>();
    public GridPanelUI m_GridPanelUI;
    public DragItemUI DragItem;

    private bool isDrag = false;
    

    private void Awake()
    {
        DragItem = GameObject.Find("StorageBoxUI").transform.Find("Item").GetComponent<DragItemUI>();

        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else if (_instance != null)
        {
            Destroy(gameObject);
        }

        LoadItem(); 
        ReLoadBoxItem();
        GridUI.OnLeftBeginDrag += GridUI_OnLeftBeginDrag;
        GridUI.OnLeftEndDrag += GridUI_OnLeftEndDrag;
    }
    
    /// <summary>
    /// Called automatiment when we start drag the item in the box
    /// </summary>
    /// <param name="gridTransform"></param>
    private void GridUI_OnLeftBeginDrag(Transform gridTransform)
    {
        if (gridTransform.childCount == 0)
        {
            
            return;
        }
        else
        {
            
            Item item = BoxDataModel.GetItem(gridTransform.name);
            //Debug.Log(item.Icon);
            DragItem.UpdateImage(item.Icon);
            //DragItem.UpdateText(item.Number);
            BoxDataModel.ReduceItem(gridTransform.name, item);
            gridTransform.GetChild(0).GetComponent<ItemUI>().UpdateText(item.Number);
            if (item.Number <= 0)
                Destroy(gridTransform.GetChild(0).gameObject);
            isDrag = true;
        }
    }

    /// <summary>
    /// Called automatiment at  the end of drag the item in the box
    /// </summary>
    /// <param name="preGrid"></param>
    /// <param name="CurPosition"></param>
    private void GridUI_OnLeftEndDrag(Transform preGrid, Transform CurPosition)
    {
        if (!isDrag) return;
        isDrag = false;
        DragItem.Hide();

       
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

       
        EtreVivant animal ;
        if (hit.collider != null && hit.collider.tag == "EtreVivant" )
        {
            animal = hit.transform.GetComponent<EtreVivant>();
            if (animal != null)
            {
                Item item = BoxDataModel.GetItem(preGrid.name);
                Dictionary<string, Item> tmp = BoxDataModel.GetGridITem();

                
                if (animal.NourrirAnimal(item.FoodType))
                {
                    
                    
                    if (item.Number == 0)
                    {
                        
                      
                        BoxDataModel.ReduceItem(preGrid.name, item);
                    }

                    GameManager.Instance.EnergieEffect(hit.collider.transform);
                }
                else
                {
                    
                    if (preGrid.childCount == 0)
                    {
                      
                        InitNewItem(item, preGrid);
                    }

                    BoxDataModel.AddItem(preGrid.name, item);

                    preGrid.GetChild(0).GetComponent<ItemUI>().UpdateText(item.Number);

                }
            }
            
        }
        else
        {

            Item item = BoxDataModel.GetItem(preGrid.name);
            Dictionary<string, Item> tmp = BoxDataModel.GetGridITem();



            Debug.Log("nothing happened2");
            if (preGrid.childCount == 0)
            {
                InitNewItem(item, preGrid);
            }

            BoxDataModel.AddItem(preGrid.name, item);

            preGrid.GetChild(0).GetComponent<ItemUI>().UpdateText(item.Number);

        }
        //Debug.Log("store " + gridName);
        



    }
   


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(ItemList[0001].Icon);
        MusicManager.Instance.MusicStop();
        MusicManager.Instance.PlayMusicByName("nature");

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle
            (GameObject.Find("StorageBoxUI").transform as RectTransform, Input.mousePosition, null, out position);

        if (isDrag)
        {
            DragItem.Show();
            DragItem.SetLocalPosition(position);
        }        


    }

    /// <summary>
    /// To store item(information) in the box
    /// </summary>
    /// <param name="itemName"></param>
    public void StoreItem(string itemName)
    {
        //Debug.Log("storeD");
        if (!ItemList.ContainsKey(itemName))
        {
            Debug.LogWarning("Doesn't exist this id");
            return;
        }
        //Debug.Log(" exist this id");
        //if the item is already in the box
        Item itemStored = ItemList[itemName];
        string gridName = BoxDataModel.FindGrid(ItemList[itemName].Name);
        Transform parentGrid;
      
        if (gridName != null)
        {
            //Debug.Log("storeA");
            GameObject canav = GameObject.Find("StorageBoxUI");
            GameObject gridpanel = canav.transform.Find("GridPanel").gameObject;
            parentGrid = gridpanel.transform.Find(gridName);
            if (parentGrid == null) Debug.Log("null");
            BoxDataModel.AddItem(gridName, itemStored);
            parentGrid.GetChild(0).GetComponent<ItemUI>().UpdateText(itemStored.Number);
        }
        else
        {
            //Debug.Log("storeB");
            parentGrid = m_GridPanelUI.GetFirstEmptyGrid();

            if (parentGrid == null)
            {
                Debug.LogWarning("box is full");
                return;
            }
            //Debug.Log("storef " + itemStored.Number);
            if (itemStored.Number == 0) itemStored.Number = 1;
            InitNewItem(itemStored, parentGrid);
        }



    }


    /// <summary>
    /// The initialization the new item 
    /// </summary>
    /// <param name="item"></param>
    /// <param name="parent"></param>
    private void InitNewItem(Item item, Transform parent)
    {
        GameObject itemPre = Resources.Load<GameObject>("Prefabs/UI/StorageBox/Item");
        itemPre.GetComponent<ItemUI>().UpdateImage(item.Icon);
        //item.Number = 1;
        //Debug.Log("storeE " + item.Number);
        itemPre.GetComponent<ItemUI>().UpdateText(item.Number);
         GameObject itemGO = Instantiate(itemPre);
        itemGO.transform.SetParent(parent);
        itemGO.transform.localPosition = Vector3.zero;
        itemGO.transform.localScale = Vector3.one;
        BoxDataModel.StoreItem(parent.name, item);




    }

    /// <summary>
    /// Reload box information when we change the scenes 
    /// </summary>
    private void ReLoadBoxItem()
    {
        Dictionary<string, Item> gridItem = BoxDataModel.GetGridITem();
        //Debug.Log(gridItem.Count + "griditemmmmm");
        if (gridItem.Count == 0) return;
        foreach(var i in gridItem)
        {
            Transform parentGrid = m_GridPanelUI.GetGridByName(i.Key);
            if(parentGrid == null)
            {
                Debug.LogWarning("this name doesn't exist");
                return;
            }
            GameObject itemPre = Resources.Load<GameObject>("Prefabs/UI/StorageBox/Item");
            Item item = i.Value;
            itemPre.GetComponent<ItemUI>().UpdateImage(item.Icon);
            itemPre.GetComponent<ItemUI>().UpdateText(item.Number);
            GameObject itemGO = Instantiate(itemPre);
            itemGO.transform.SetParent(parentGrid);
            itemGO.transform.localPosition = Vector3.zero;
            itemGO.transform.localScale = Vector3.one;


        }
    }

    /// <summary>
    /// Initialisation the information of the food
    /// </summary>
    private void LoadItem()
    {
        Food bone = new Food(0001, "Bone", " ", "Images/Foods/bone",1,
                        NourritureType.OSVIANDE);
        Food grass = new Food(0002, "Grass", " ", "Images/Foods/grass",1,
                        NourritureType.HERBE);

        Food meat = new Food(0003, "Meat", " ", "Images/Foods/meat",1,
                        NourritureType.STEAK);
        Food fish = new Food(0004, "Fish", " ", "Images/Foods/fish",1,
                        NourritureType.POISSON);
        Food seed = new Food(0005, "Seed", " ", "Images/Foods/seed", 1,
                        NourritureType.GRAINES);




        ItemList.Add(bone.Name, bone);
        ItemList.Add(grass.Name, grass);
        ItemList.Add(meat.Name, meat);
        ItemList.Add(fish.Name, fish);
        ItemList.Add(seed.Name, seed);


    }
}
