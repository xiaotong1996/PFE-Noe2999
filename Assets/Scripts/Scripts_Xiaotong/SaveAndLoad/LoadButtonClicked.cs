using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// unsed.
/// </summary>
public class LoadButtonClicked : MonoBehaviour
{
    public void Click()
    {
        //Debug.Log("Button Clicked. TestClick.");
        //Debug.Log(Application.persistentDataPath);
        if (mySaveLoad.Load())
        {
            Debug.Log("Load successfully");
        }
        else
        {
            Debug.Log("Load failed");
        }
    }
}
