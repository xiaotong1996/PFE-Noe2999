using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Unsed
/// </summary>
public class DeleteSavedGame : MonoBehaviour
{
    public void Click()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            try
            {
                File.Delete(Application.persistentDataPath + "/savedGames.gd");
            }
            catch (System.IO.IOException e)
            {
                Debug.Log(e.Message);
                return;
            }
        }
    }
}
