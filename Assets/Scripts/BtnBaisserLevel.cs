using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// help control sea level UI
/// </summary>
public class BtnBaisserLevel : MonoBehaviour
{
    

    public float valueBaisserLevel = 5f;
    public void ClickBtn()
    {
        if (!AnimalDataModel.isPause && !GameManager.Instance.IsSleep)
        {
        
            GameManager.Instance.UpdateSeaLevel(valueBaisserLevel);
        }

    }
    

 
}
