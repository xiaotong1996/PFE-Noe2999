using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte 
{
    private List<Destination> destinations;
    private Destination destinationActuelle;

    public Destination DestinationActuelle { get => destinationActuelle; set => destinationActuelle = value; }
    public List<Destination> Destinations { get => destinations; set => destinations = value; }

    public Carte()
    {

    }
}
