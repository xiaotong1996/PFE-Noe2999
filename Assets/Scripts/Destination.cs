using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    #region Variable
    private Vector2 positionDansLaCarte;
    //private Dictionary<Destination, int> tempsVersAutresDestinations;
    private Ecosysteme ecosysteme;
    //private Dictionary<Ressource, int> ressources;

    [SerializeField]
    private List<EtreVivant> etreVivant;

    private new string name;
    private float hauteur;
    private bool dejaVu;
    //private Meteo meteo;

    //public Dictionary<Destination, int> TempsVersAutresDestinations { get => tempsVersAutresDestinations; set => tempsVersAutresDestinations = value; }

    public Ecosysteme Ecosysteme { get => ecosysteme; set => ecosysteme = value; }

    public string Name { get => name; set => name = value; }

    public float Hauteur { get => hauteur; set => hauteur = value; }

    public bool DejaVu { get => dejaVu; set => dejaVu = value; }

    public Vector2 PositionDansLaCarte { get => positionDansLaCarte; set => positionDansLaCarte = value; }

    public List<EtreVivant> EtreVivant { get => etreVivant; set => etreVivant = value; }


    #endregion

    

    private void Awake()
    {
        System.Array values = System.Enum.GetValues(typeof(EcosystemeType));
        

        PositionDansLaCarte = new Vector2(Random.Range(-7.0f, 7.0f), Random.Range(-6.0f, 6.0f));

        EcosystemeType randomEcosystemType = (EcosystemeType)values.GetValue(Random.Range(0,values.Length));
        Ecosysteme = new Ecosysteme(randomEcosystemType);
        Name = randomEcosystemType.ToString() + Random.Range(1000, 9999);
        Hauteur = Random.Range(0.0f, 50.0f);

        transform.Translate(PositionDansLaCarte);
    }



}
