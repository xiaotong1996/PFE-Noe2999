using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaisseau : MonoBehaviour
{
    private static Vaisseau instance;
    public static Vaisseau Instance { get; private set; }


    private Dictionary<Salle, int> salles;
    public Dictionary<Salle, int> Salles { get => salles; set => Salles = value; }

    [SerializeField]
    private int energiemax = 10;
    public int Energiemax { get => energiemax; private set => energiemax = value; }

    [SerializeField]
    private int energie = 0;
    public int Energie { get => energie; private set => energie = value; }


    [SerializeField]
    private int nourritureMax = 10;
    public int NourritureMax { get => nourritureMax;  set => nourritureMax = value; }


    [SerializeField]
    private int nourritureVeg = 0;
    public int NourritureVeg { get => nourritureVeg;  set => energie = value; }

    [SerializeField]
    private int nourritureViande = 0;
    public int NourritureViande { get => nourritureViande;  set => nourritureViande = value; }


    [SerializeField]
    private int materiauxMax = 10;
    public int MateriauxMax { get => materiauxMax;  set => materiauxMax = value; }

    [SerializeField]
    private int materiaux = 0;
    public int Materiaux { get => materiaux;  set => materiaux = value; }
    //currentposition
    //nextposition

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

    void Move()
    {
       
    }

    void AjouterEnergie(int n_energie)
    {
        if (Energie == Energiemax)
            Debug.Log("Energie est max！");
        else if (Energie + n_energie > Energiemax)
        //TODO 
        
            Energie = Energiemax;
        
        else
            Energie += n_energie;
    }


    void ConsommerEnergie(int n_energie)
    {
        if (Energie == 0)
            Debug.Log(" il n'y a plus d'energie");
        else if (Energie - n_energie < 0)
        //TODO 
        {
            Energie = 0;
            Debug.Log(" il n'y a plus d'energie");
        }
        else
            Energie -= Energiemax;
    }


    void AjouterNourritureVeg(int n_veg)
    {
        if (NourritureVeg + NourritureViande == NourritureMax)
            Debug.Log("Nourriture est max！");
        else if (NourritureVeg + NourritureViande + n_veg > NourritureMax)
            //TODO 
            NourritureVeg += n_veg;
        else
            NourritureVeg += n_veg;
    }


    public void ConsommerNourritureVeg(int n_veg)
    {
        if (NourritureVeg == 0)
            Debug.Log(" il n'y a plus de NourritureVeg");
        else if (NourritureVeg - n_veg < 0)
        //TODO 
        {
            NourritureVeg = 0;
            Debug.Log(" il n'y a plus d'energie");
        }
        else
            NourritureVeg -= n_veg;
    }

    public void AjouterNourritureViande(int n_viand)
    {
        if (NourritureVeg + NourritureViande == NourritureMax)
            Debug.Log("Nourriture est max！");
        else if (NourritureVeg + NourritureViande + n_viand > NourritureMax)
            //TODO 
            NourritureViande += n_viand;
        else
            NourritureViande += n_viand;
    }


    public void ConsommerNourritureViande(int n_viand)
    {
        if (NourritureViande == 0)
            Debug.Log(" il n'y a plus de NourritureViandw");
        else if (NourritureViande - n_viand < 0)
        //TODO 
        {
            NourritureViande = 0;
            Debug.Log(" il n'y a plus de NourritureViandw");
        }
        else
            NourritureViande -= n_viand;
    }

    void AjouterMateriaux(int n_materiaux)
    {
        if (Materiaux == MateriauxMax)
            Debug.Log("Nourriture est max！");
        else if (Materiaux > NourritureMax)
            //TODO 
            NourritureViande += n_materiaux;
        else
            NourritureViande += n_materiaux;
    }

    void ConsommerMateriaux(int n_materiaux)
    {
        if (Materiaux == 0)
            Debug.Log(" il n'y a plus de Materiaux");
        else if (Materiaux - n_materiaux < 0)
        //TODO 
        {
            n_materiaux = 0;

            Debug.Log(" il n'y a plus de Materiaux");
        }
        else
            n_materiaux -= n_materiaux;
    }

    //avant d'effectuer un mouvement, vérifier que SalleEmbarquement et SalleNaissance sont vides ! (Sinon le mouvement n'est pas possible)
    void MoveMent(Transform currentIle, Transform destination)
    {
        //TODO
    }

    void AjouterSalle()
    { //TODO
    }
    

}
