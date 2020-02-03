using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class to save information about the animals on the boat
/// </summary>
public class VaisseauDataManager : MonoBehaviour
{
    private Dictionary<EtreVivant, int> dataModel = AnimalDataModel.GetDataModel();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var pair in dataModel)
        {
            TempsQuiPasse(pair.Key);
            //Debug.Log(pair.Key.Fatigue);
        }
    }

    /// <summary>
    /// Update the information about the animals each frame
    /// </summary>
    /// <param name="animal"></param>
    private void TempsQuiPasse( EtreVivant animal)
    {
       
        animal.Chronometre += Time.deltaTime;
        if (animal.Chronometre >= animal.Chronolimite)
        {
            animal.Chronometre = 0f;
            if (GameManager.Instance.IsSleep == false)
            {
                animal.Estomac -= 0.5f;
                animal.Fatigue -= (0.1f * Time.deltaTime);
                if (animal.Fatigue < 0)
                {
                    animal.Fatigue = 0f;
                }
                if (animal.Estomac < 0)
                {
                    animal.Estomac = 0;
                }
                //if (UnityEngine.Random.value >= 0.5)
                //{
                //    animal.DisplayHumeur();
                //}
            }
            else
            {
                Debug.Log("trueeeeeee");
                // problème : ça risque de ne pas se recharger si je quitte l'application !
                animal.Fatigue += 0.3f;
                if (animal.Fatigue > 10f)
                {
                    animal.Fatigue = 10f;
                }
            }


       }
        AnimalDataModel.UpdateAnimalInfo(animal);
    }
}
