using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputMouseManager : MonoBehaviour
{
    bool isOpen = true;
    public GameObject Panel;

       // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("StorageBoxUI").transform.Find("GridPanel").gameObject;
        Panel.SetActive(true);
       
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "vaiseau_Ile" || SceneManager.GetActiveScene().name == "Vaisseau"     )
        {
            Panel.SetActive(true);
        }

        else Panel.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("click");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                //_Tag = hit.collider.tag;
               // Debug.Log(hit.collider.tag);
                if(hit.collider.tag == "Food")
                {
                    //StorageBoxManager.Instance.StoreItem(hit.collider.GetComponent<FoodInfo>().Name);
                    ////Debug.Log(hit.collider.name);
                    
                    //Destroy(hit.collider.gameObject);
                }

                if(hit.collider.name == "Chest_Button")
                {
                    isOpen = !isOpen;
                    Panel.SetActive(isOpen);
                }



            }
        }


    }

    public void OnButtonClick()
    {
        if (!AnimalDataModel.isPause)
        {
            isOpen = !isOpen;
            Panel.SetActive(isOpen);
        }
    }


}
