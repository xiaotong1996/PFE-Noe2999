using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mySaveGame : MonoBehaviour
{
    public void Click()
    {
        Debug.Log("Game saved.");
        mySaveLoad.Save();
        
    }
}
