using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaisseau : MonoBehaviour
{
    private static Vaisseau instance;
    public static Vaisseau Instance { get; private set; }


    //private List<Salle> salles; 
    // public List<Salle> Salles { get => salles; set => Salles = value; }

    [SerializeField]
    private int energiemax = 10;
    public int Energiemax { get => energiemax; set => energiemax = value; }

    [SerializeField]
    private int energie = 0;
    public int Energie { get => energie; set => energie = value; }


    [SerializeField]
    private int nourritureMax = 10;
    public int NourritureMax { get => nourritureMax; set => nourritureMax = value; }


    [SerializeField]
    private int nourritureVeg = 0;
    public int NourritureVeg { get => nourritureVeg; set => energie = value; }

    [SerializeField]
    private int nourritureViande = 0;
    public int NourritureViande { get => nourritureViande; set => nourritureViande = value; }


    [SerializeField]
    private int materiauxMax = 10;
    public int MateriauxMax { get => materiauxMax; set => materiauxMax = value; }

    [SerializeField]
    private int materiaux = 0;
    public int Materiaux { get => materiaux; set => materiaux = value; }


    private void Awake()
    {
        Debug.Assert(Vaisseau.Instance == null);
        Vaisseau.Instance = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
