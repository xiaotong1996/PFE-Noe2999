using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BtnBaisserLevel : MonoBehaviour
{
    // Start is called before the first frame update

    public float valueBaisserLevel = 5f;
    public void ClickBtn()
    {
        if (!AnimalDataModel.isPause)
        {
            Debug.Log("click");
            GameManager.Instance.UpdateSeaLevel(valueBaisserLevel);
        }

    }
    

 
}
