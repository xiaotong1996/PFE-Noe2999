using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Destination : MonoBehaviour
{
    #region Variable
    private Vector2 positionDansLaCarte;
    //private Dictionary<Destination, int> tempsVersAutresDestinations;
    private Ecosysteme ecosysteme;
    //private Dictionary<Ressource, int> ressources;

    [SerializeField]
    private List<EnumRace> etreVivant;

    private new string name;
    private float hauteur;
    private bool dejaVu;
    //private Meteo meteo;

    //public Dictionary<Destination, int> TempsVersAutresDestinations { get => tempsVersAutresDestinations; set => tempsVersAutresDestinations = value; }

    public Ecosysteme Ecosysteme { get => ecosysteme; set => ecosysteme = value; }

    public string Name { get => name; set => name = value; }

    public float Hauteur { get => hauteur; set => hauteur = value; }

    public bool DejaVu { get => dejaVu; set => dejaVu = value; }

    public Vector3 PositionDansLaCarte { get => positionDansLaCarte; set => positionDansLaCarte = value; }

    public List<EnumRace> EtreVivant { get => etreVivant; set => etreVivant = value; }


    #endregion

    

    private void Awake()
    {
        PositionDansLaCarte = transform.position;

        System.Array ecosysteme = System.Enum.GetValues(typeof(EcosystemeType));

        EcosystemeType randomEcosystemType = (EcosystemeType)ecosysteme.GetValue(Random.Range(0,ecosysteme.Length));

        //for test
        switch (randomEcosystemType)
        {
            case EcosystemeType.FORET:
                randomEcosystemType = EcosystemeType.PLAINE;
                break;
            case EcosystemeType.DESERT:
                randomEcosystemType = EcosystemeType.PLAINE;
                break;
            case EcosystemeType.NEIGE:
                randomEcosystemType = EcosystemeType.SAVANE;
                break;
            case EcosystemeType.PLAINE:
                break;
            case EcosystemeType.SAVANE:
                break;
            default:
                break;
        }

        System.Array races = System.Enum.GetValues(typeof(EnumRace));
        var raceNum = Random.Range(1, 2);
        for(int i = 0; i < raceNum; i++)
        {
            EnumRace randomraceType = (EnumRace)races.GetValue(Random.Range(0, races.Length));
            EtreVivant.Add(randomraceType);
            //switch (randomraceType)
            //{
            //    case EnumRace.CHAT:
            //        EtreVivant.Add(new Chat());
            //        break;
            //    case EnumRace.CHIEN:
            //        EtreVivant.Add(new Chien());
            //        break;
            //    case EnumRace.POULE:
            //        EtreVivant.Add(new Poule());
            //        break;
            //    case EnumRace.LION:
            //        EtreVivant.Add(new Lion());
            //        break;
            //    case EnumRace.ZEBRE:
            //        EtreVivant.Add(new Zebre());
            //        break;
            //    default:
            //        break;
            //}
        }

        Ecosysteme = new Ecosysteme(randomEcosystemType);

        Hauteur = Random.Range(0.0f, 50.0f);

        Name = randomEcosystemType.ToString() + Random.Range(1000, 9999);

    }



}
