using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private Vaisseau vaisseau;
    private Carte carte;
    private GameObject joueurDestination;

    //new
    private float seaLevelMax = 2000;

    //[SerializeField]
    private float seaLevel = 2000;
    [SerializeField]
    private int date = 0;

    //new
    [SerializeField]
    private float speedSeaLevel = 0.5f; //la vitesse pour controller le sealevel augmenter ou desendre
    [SerializeField]
    private int energiemax = 100;
    public int Energiemax { get => energiemax; private set => energiemax = value; }

    [SerializeField]
    private float energie = 100;
    public float Energie { get => energie; private set => energie = value; }

    [SerializeField]
    private float energyAddPerFrame=0.1f;

    public Carte Carte { get => carte; set => carte = value; }
    public GameObject JoueurDestination { get => joueurDestination; set => joueurDestination = value; }
   
   // private float SeaLevel  { get => seaLevel; set => seaLevel = value; }
    public int Date { get => date; set => date = value; }
    public float SeaLevel { get => seaLevel; set => seaLevel = value; }

    public bool IsSleep = false;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        SeaLevel = UIDataModel.GetSeaLevel();
    }
    // Start is called before the first frame update
    void Start()
    {
        SeaLevel = 2000;
        Energie = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateSeaLevel();
        //Debug.Log("gamemamanger" + seaLevel);
        //UIDataModel.SetSeaLevel(seaLevel);
        UIManager.Instance.SetSeaLevelMax(seaLevelMax);
        UIManager.Instance.UpdateSeaLevel(SeaLevel);
        UIManager.Instance.SetEnergyMax(Energiemax);
        UIManager.Instance.UpdateEnergyslider(Energie);

        GetDestination();

        AjouterEnergie(energyAddPerFrame * Time.deltaTime);

    }

  

   public  void AjouterEnergie(float n_energie)
    {
        if (Energie == Energiemax)
            return;
        //Debug.Log("Energie est max！");
        else if (Energie + n_energie > Energiemax)
            //TODO 

            Energie = Energiemax;

        else
            Energie += n_energie;
    }


    public void ConsommerEnergie(float n_energie)
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
            Energie -= n_energie;
    }
    public void UpdateSeaLevel(float value)
    {

        Debug.Log("seaLevel" + seaLevel);
        Debug.Log("energie" + energie);
        if (Energie >= 10)
        {
            seaLevel -= value;
            //if (seaLevel > 1)
            //    seaLevel -= speedSeaLevel * Time.deltaTime;

            ConsommerEnergie(10);
        }
        //if (SeaLevel > 0)
        //    Debug.Log("WIN!");

        //SeaLevel += speedSeaLevel * Time.deltaTime;
        //if (SeaLevel < 0)
        //    Debug.Log("LOSE!");
    }

    /*
     *@param nombre Ajouter combien de jour pour la date 
     */

    void UpdateDate(int nombre)
    {
        date += nombre;
    }

    void GetDestination()
    {
        var vaisseau = GameObject.FindGameObjectWithTag("Vaisseau");
        if (vaisseau != null)
        {
            var checkarrived = vaisseau.GetComponent<CheckArrived>();
           
            JoueurDestination = checkarrived.DestinationStay;
        }
    }



}
