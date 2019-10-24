using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    private Dictionary<Destination, int> tempsVersAutresDestinations;
    private Ecosysteme ecosysteme;
    //private Dictionary<Ressource, int> ressources;
    public List<EtreVivant> etreVivant;
    private new string name;
    private int hauteur;
    private bool dejaVu;
    //private Meteo meteo;

    public Dictionary<Destination, int> TempsVersAutresDestinations { get => tempsVersAutresDestinations; set => tempsVersAutresDestinations = value; }

    public Ecosysteme Ecosysteme { get => ecosysteme; set => ecosysteme = value; }

    public string Name { get => name; set => name = value; }

    public int Hauteur { get => hauteur; set => hauteur = value; }

    public bool DejaVu { get => dejaVu; set => dejaVu = value; }

    
}
