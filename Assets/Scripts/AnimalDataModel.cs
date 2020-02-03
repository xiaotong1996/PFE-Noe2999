using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// It is a clase for saving the animals datas in order to Synchronize animal data
/// in different scenes
/// </summary>
public static class AnimalDataModel 
{
    //animal and salle ID
    private static Dictionary<EtreVivant, int> dataModel = new Dictionary<EtreVivant, int>();
    public static bool isPause = false;

    /// <summary>
    /// To add an new animal in the dictionary
    /// </summary>
    /// <param name="idx"> the id of the room this animal will be in/param>
    /// <param name="animal"></param>
    public static void AddAnimal(int idx, EtreVivant animal)
    {
      
        dataModel.Add(animal, idx);
    }

    /// <summary>
    /// To get the id of room that contain this animal
    /// </summary>
    /// <param name="animal"></param>
    /// <returns>room id</returns>
    public static int FindSalleIdx(EtreVivant animal)
    {
        return dataModel[animal];
    }

    /// <summary>
    /// To update animal data
    /// </summary>
    /// <param name="animal"></param>
    public static void UpdateAnimalInfo(EtreVivant animal)
    {
        foreach(var pair in dataModel)
        {
            if(animal.Id == pair.Key.Id)
            {
                pair.Key.Estomac = animal.Estomac;

                pair.Key.Fatigue = animal.Fatigue;

                pair.Key.Chronolimite = animal.Chronolimite;

                pair.Key.Chronometre = animal.Chronometre;

                pair.Key.ChronoSprite = animal.ChronoSprite;

                pair.Key.EstEnTrainDeDormir = animal.EstEnTrainDeDormir;
            }
        }
    }

    /// <summary>
    /// To set room id
    /// </summary>
    /// <param name="animal"></param>
    /// <param name="idx"></param>
    public static void SetSalleIdx(EtreVivant animal,int idx)
    {
        
        string animalId = animal.Id;
        foreach(var pair in dataModel)
        {
            if (pair.Key.Id == animalId)
            {
                dataModel[pair.Key] = idx;
                return;
            }
            
        }
        dataModel[animal] = idx;
       

    }

    /// <summary>
    /// delete an animal 
    /// </summary>
    /// <param name="animal"></param>
    public static void RemoveAnimal(EtreVivant animal)
    {
        foreach(var pair in dataModel)
        {
            if(animal.Id == pair.Key.Id)
            {
                dataModel.Remove(pair.Key);
                break;
            }
        }
        
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns>return the dictionary</returns>
    public static Dictionary<EtreVivant, int> GetDataModel()
    {
        return dataModel;
    }
}
