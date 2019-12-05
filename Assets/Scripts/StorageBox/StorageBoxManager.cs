using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;

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
        //GridUI.OnEnter

       
        ReLoadBoxItem();
        GridUI.OnLeftBeginDrag += GridUI_OnLeftBeginDrag;
        GridUI.OnLeftEndDrag += GridUI_OnLeftEndDrag;

    }


    private void GridUI_OnLeftBeginDrag(Transform gridTransform)
    {
        if (gridTransform.childCount == 0)
        {
            
            return;
        }
        else
        {
            
            Item item = BoxDataModel.GetItem(gridTransform.name);
            Debug.Log(item.Icon);
            DragItem.UpdateImage(item.Icon);
            //DragItem.UpdateText(item.Number);
            BoxDataModel.ReduceItem(gridTransform.name, item);
            gridTransform.GetChild(0).GetComponent<ItemUI>().UpdateText(item.Number);
            if (item.Number <= 0)
                Destroy(gridTransform.GetChild(0).gameObject);
            isDrag = true;
        }
    }


    private void GridUI_OnLeftEndDrag(Transform preGrid, Transform CurPosition)
    {
        isDrag = false;
        DragItem.Hide();
       
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        string entreTag="a";

        if (hit.collider!=null)
        {
            
            entreTag = hit.transform.tag;
            
        }

        Item item = BoxDataModel.GetItem(preGrid.name);
        Dictionary<string, Item> tmp = BoxDataModel.GetGridITem();
        
        
        if (entreTag == "Herbivore" && item.FoodType == NourritureType.NOURRITUREVEG
            || entreTag == "Carnivore" && item.FoodType == NourritureType.NOURRITUREVIANDE)
        {
            //BoxDataModel.DeleteItem
            //TODO
            Debug.Log(hit.collider.name + "eats the " + item.Name + "!");
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
   


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(ItemList[0001].Icon);
        
        
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

    public void StoreItem(string itemName)
    {

        if(!ItemList.ContainsKey(itemName))
        {
            Debug.LogWarning("Doesn't exist this id");
            return;
        }

        //if the item is already in the box
        Item itemStored = ItemList[itemName];
        string gridName = BoxDataModel.FindGrid(ItemList[itemName].Name);
        Transform parentGrid;
        if (gridName != null)
        {
            GameObject canav = GameObject.Find("StorageBoxUI");
            GameObject gridpanel = canav.transform.Find("GridPanel").gameObject;
            parentGrid = gridpanel.transform.Find(gridName);
            if (parentGrid == null) Debug.Log("null");
            BoxDataModel.AddItem(gridName, itemStored);
            parentGrid.GetChild(0).GetComponent<ItemUI>().UpdateText(itemStored.Number);
        }
        else
        {
            parentGrid = m_GridPanelUI.GetFirstEmptyGrid();

            if (parentGrid == null)
            {
                Debug.LogWarning("box is full");
                return;
            }
            InitNewItem(itemStored, parentGrid);
        }

        

        
        
    }

    private void InitNewItem(Item item, Transform parent)
    {
        GameObject itemPre = Resources.Load<GameObject>("Prefabs/UI/StorageBox/Item");
        itemPre.GetComponent<ItemUI>().UpdateImage(item.Icon);
        itemPre.GetComponent<ItemUI>().UpdateText(item.Number);
         GameObject itemGO = Instantiate(itemPre);
        itemGO.transform.SetParent(parent);
        itemGO.transform.localPosition = Vector3.zero;
        itemGO.transform.localScale = Vector3.one;
        BoxDataModel.StoreItem(parent.name, item);


    }

    private void ReLoadBoxItem()
    {
        Dictionary<string, Item> gridItem = BoxDataModel.GetGridITem();
        Debug.Log(gridItem.Count + "griditemmmmm");
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

    private void LoadItem()
    {
        Food apple = new Food(0001, "Apple", " ", "Images/Foods/apple",1,
                        NourritureType.NOURRITUREVEG);
        Food banana = new Food(0002, "Banana", " ", "Images/Foods/bananas",1,
                        NourritureType.NOURRITUREVEG);

        Food chicken = new Food(0003, "Chicken", " ", "Images/Foods/chicken",1,
                        NourritureType.NOURRITUREVIANDE);
        Food fish = new Food(0004, "Fish", " ", "Images/Foods/fish",1,
                        NourritureType.NOURRITUREVIANDE);


        ItemList.Add(apple.Name, apple);
        ItemList.Add(banana.Name, banana);
        ItemList.Add(chicken.Name, chicken);
        ItemList.Add(fish.Name, fish);
        

    }
}
