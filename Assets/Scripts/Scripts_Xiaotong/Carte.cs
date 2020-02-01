using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte : MonoBehaviour
{
    [SerializeField]
    private int nombreDeDestination;

    [SerializeField]
    private GameObject destinationPrefab;

    private List<Destination> destinations;
    private Destination destinationActuelle;
    

    public Destination DestinationActuelle { get => destinationActuelle; set => destinationActuelle = value; }
    public List<Destination> Destinations { get => destinations; set => destinations = value; }
    public int NombreDeDestination { get => nombreDeDestination; set => nombreDeDestination = value; }
   
    public GameObject DestinationPrefab { get => destinationPrefab; set => destinationPrefab = value; }


    private void Awake()
    {
        Destinations = new List<Destination>();
        Debug.Log(nombreDeDestination);
        for (int i = 0; i < nombreDeDestination; ++i)
        {
            Instantiate(DestinationPrefab);
            Destinations.Add(DestinationPrefab.GetComponent<Destination>());
        }
        DestinationActuelle = Destinations[0];
    }
}
