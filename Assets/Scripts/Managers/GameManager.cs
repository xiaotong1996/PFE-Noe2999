using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is a singleton, to several data global
/// </summary>
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
    private int energiemax = 100;
    public int Energiemax { get => energiemax; private set => energiemax = value; }

    [SerializeField]
    private float energie = 100;
    public float Energie { get => energie; private set => energie = value; }

    [SerializeField]
    private float energyAddPerFrame=0f;

    public Carte Carte { get => carte; set => carte = value; }
    public GameObject JoueurDestination { get => joueurDestination; set => joueurDestination = value; }

    public float SeaLevel { get => seaLevel; set => seaLevel = value; }

    public bool IsSleep = false;

    public GameObject heart;
    private Transform heartContainer;


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
        GameObject heartContainerObject;
        heartContainerObject = GameObject.Find("heartContainer");
        if (heartContainerObject != null) heartContainer = heartContainerObject.transform;          

        // To update sea level UI and energy UI each frame 
        UIManager.Instance.SetSeaLevelMax(seaLevelMax);
        UIManager.Instance.UpdateSeaLevel(SeaLevel);
        UIManager.Instance.SetEnergyMax(Energiemax);
        UIManager.Instance.UpdateEnergyslider(Energie);

        GetDestination();

        AjouterEnergie(energyAddPerFrame * Time.deltaTime);

        CheckWin();


    }

    void CheckWin()
    {
        if (SeaLevel <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    /// <summary>
    /// Add energy
    /// </summary>
    /// <param name="n_energie">the number of energy need to be added</param>
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

    /// <summary>
    /// Use energy
    /// </summary>
    /// <param name="n_energie">the number of energy need to be used</param>
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

    /// <summary>
    /// Update sealevel data
    /// </summary>
    /// <param name="value"></param>
    public void UpdateSeaLevel(float value)
    {

        //Debug.Log("seaLevel" + seaLevel);
        //Debug.Log("energie" + energie);
        if (Energie >= 10)
        {
            seaLevel -= value;
          
            ConsommerEnergie(10);
        }

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
    public void EnergieEffect(Transform depart)
    {
        GameObject instanciedHeart = Instantiate(heart);
        instanciedHeart.transform.SetParent(heartContainer);
        Debug.Log("ok");
        instanciedHeart.transform.position = depart.position;

    }


}
