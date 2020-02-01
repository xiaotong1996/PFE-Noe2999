using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class mySaveLoad 
{
    public static List<Game> savedGames = new List<Game>();

    public static void Save()
    {
        //Game currentGame = new Game();
        //string json = JsonUtility.ToJson(currentGame);
        //Debug.Log("Saving as JSON: " + json);

        //savedGames.Add(currentGame);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        //bf.Serialize(file, mySaveLoad.savedGames);
        //file.Close();
    }


    public static bool Load()
    {
        //if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
        //    mySaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
        //    file.Close();

        //    LoadAll();
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        return true;
    }

    private static void LoadAll()
    {
        if (savedGames[0] != null)
        {
            var game = savedGames[0];
            string json = JsonUtility.ToJson(game);

            Debug.Log("Saving as JSON: " + json);
        }
    }
}
