using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAnimaux : MonoBehaviour
{
    private GameObject currentDestination;

    public GameObject chatPrefab;
    public GameObject chienPrefab;
    public GameObject poulePrefab;
    public GameObject lionPrefab;
    public GameObject zebrePrefab;

    public GameObject CurrentDestination { get => currentDestination; set => currentDestination = value; }

    // Start is called before the first frame update
    void Start()
    {
        
        currentDestination = GameManager.Instance.JoueurDestination;
        if (currentDestination != null)
        {
            LoadPrefab();
            InstanseAnimaux();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadPrefab()
    {
        chatPrefab = Resources.Load<GameObject>("Prefabs/Animals/cat");
        chienPrefab= Resources.Load<GameObject>("Prefabs/Animals/dog");
        poulePrefab= Resources.Load<GameObject>("Prefabs/Animals/hen");
        lionPrefab= Resources.Load<GameObject>("Prefabs/Animals/lion");
        zebrePrefab= Resources.Load<GameObject>("Prefabs/Animals/zebra");

    }

    void InstanseAnimaux()
    {
        var animauxList = currentDestination.GetComponent<Destination>().EtreVivant;
        foreach(var animal in animauxList)
        {
            var position = new Vector3(Random.Range(-7.9f, -3.7f), Random.Range(-2.1f, 3.6f), -0.5f);
            switch (animal)
            {
                case EnumRace.CHAT:
                    var animalGameObject=Instantiate(chatPrefab, position, Quaternion.identity);
                    animalGameObject.GetComponent<Chat>().PositionDestination = CurrentDestination.GetComponent<Destination>();
                    break;
                case EnumRace.CHIEN:
                    animalGameObject = Instantiate(chienPrefab, position, Quaternion.identity);
                    animalGameObject.GetComponent<Chien>().PositionDestination = CurrentDestination.GetComponent<Destination>();
                    Debug.Log(animalGameObject.GetComponent<Chien>().Fatigue + "chien");
                    break;
                case EnumRace.POULE:
                    animalGameObject = Instantiate(poulePrefab, position, Quaternion.identity);
                    animalGameObject.GetComponent<Poule>().PositionDestination = CurrentDestination.GetComponent<Destination>();
                    break;
                case EnumRace.LION:
                    animalGameObject = Instantiate(lionPrefab, position, Quaternion.identity);
                    animalGameObject.GetComponent<Lion>().PositionDestination = CurrentDestination.GetComponent<Destination>();
                    break;
                case EnumRace.ZEBRE:
                    animalGameObject = Instantiate(zebrePrefab, position, Quaternion.identity);
                    animalGameObject.GetComponent<Zebre>().PositionDestination = CurrentDestination.GetComponent<Destination>();
                    break;
                default:
                    break;
            }
          


        }
    }
}
