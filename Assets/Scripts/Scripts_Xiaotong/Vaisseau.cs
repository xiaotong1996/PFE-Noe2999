using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaisseau : MonoBehaviour
{
    private static Vaisseau instance;
    public static Vaisseau Instance  { get { return instance; } }

    [SerializeField]
    private Dictionary<int, SalleAnimaux> salles = new Dictionary<int, SalleAnimaux>();
    public Dictionary<int, SalleAnimaux> Salles { get => salles; set => Salles = value; }

    


    [SerializeField]
    private int nourritureMax = 10;
    public int NourritureMax { get => nourritureMax;  set => nourritureMax = value; }


    [SerializeField]
    private int nourritureVeg = 0;
    public int NourritureVeg { get => nourritureVeg;  set => nourritureVeg = value; }

    [SerializeField]
    private int nourritureViande = 0;
    public int NourritureViande { get => nourritureViande;  set => nourritureViande = value; }
    public SalleAnimaux[] s;
    //[SerializeField]
    //private Transform[] salles;
    //public Transform[] Salles { get => salles; set => salles = value; }

    private void Awake()
    {
        if (instance == null)
        {
            
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
       
        //Debug.Log(s.Length);
        int i = 0;

        foreach(SalleAnimaux v in s)
        {
            //Debug.Log("vaisseua " + v.name + " " + i);
            salles.Add(i++, v);
            
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {

        
        Init();
        foreach(var pair in Salles)
        {
            //Debug.Log("aa " + pair.Key + " " + pair.Value.name + " " + pair.Value.Animaux.Count);
            Transform salleTransform = pair.Value.transform;
            
            SalleAnimaux s = pair.Value;
            foreach(var a in s.Animaux)
            {
                float x = Random.Range(-0.5f, 0.5f) + salleTransform.position.x;

                float y = Random.Range(-0.5f, 0.5f) + salleTransform.position.y;
                Vector3 pos = new Vector3(x, y, -0.5f);
                GameObject prefab = (GameObject)Resources.Load("Prefabs/Animals/cat");
                if (a.Race == EnumRace.CHAT)
                     prefab = (GameObject)Resources.Load("Prefabs/Animals/cat");
                else if(a.Race == EnumRace.CHIEN)
                    prefab = (GameObject)Resources.Load("Prefabs/Animals/dog");
                else if (a.Race == EnumRace.LION)
                    prefab = (GameObject)Resources.Load("Prefabs/Animals/lion");
                else if (a.Race == EnumRace.POULE)
                    prefab = (GameObject)Resources.Load("Prefabs/Animals/hen");
                else if (a.Race == EnumRace.ZEBRE)
                    prefab = (GameObject)Resources.Load("Prefabs/Animals/zebra");
               
                GameObject tmp = Instantiate(prefab, pos, Quaternion.identity);
                Debug.Log(a.Id + "value");
                EtreVivant e = tmp.GetComponent<EtreVivant>();
                //Debug.Log(e.Fatigue + " "+"value");
                
                tmp.transform.SetParent(s.transform);
                e.EtreVivantCopy(a);
                e.PositionSalle = s;
               e.Id = a.Id;
                Debug.Log(tmp.GetComponent<EtreVivant>().Id + " " + "value2e");




            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
       
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

  
    private void Init()
    {
        Debug.Log("value");
        Dictionary<EtreVivant, int> datamodel = AnimalDataModel.GetDataModel();
        //Salles.Clear();
        foreach(var pair in datamodel)
        {
            Salles[pair.Value].Animaux.Add(pair.Key);
            Debug.Log("value" + " " + pair.Key.Fatigue);
            
        }

    }

    private void UpdateDataMOdel()
    {
        
    }

}
