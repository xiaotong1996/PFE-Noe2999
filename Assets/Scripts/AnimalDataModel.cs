using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimalDataModel 
{
    //animal et salle ID
    private static Dictionary<EtreVivant, int> dataModel = new Dictionary<EtreVivant, int>();
    public static bool isPause = false;
    public static void AddAnimal(int idx, EtreVivant animal)
    {
        Debug.Log("add");
        dataModel.Add(animal, idx);
    }

    public static int FindSalleIdx(EtreVivant animal)
    {
        return dataModel[animal];
    }


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
    public static void SetSalleIdx(EtreVivant animal,int idx)
    {
        Debug.Log("set");
        string animalId = animal.Id;
        foreach(var pair in dataModel)
        {
            if (pair.Key.Id == animalId)
            {
                dataModel[pair.Key] = idx;
                return;
            }
            
        }

       // AddAnimal(idx, animal);
            dataModel[animal] = idx;
        Debug.Log(animal.name);

    }

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

    public static Dictionary<EtreVivant, int> GetDataModel()
    {
        return dataModel;
    }
}
