using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// unused
/// </summary>
public class mySaveGame : MonoBehaviour
{
    public void Click()
    {
        Debug.Log("Game saved.");
        mySaveLoad.Save();
        
    }
}
