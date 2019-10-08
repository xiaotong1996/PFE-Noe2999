using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance { get; private set; }
    
    private Vaisseau vaisseau;
    private Carte carte;
    private Destination joueurDestination;

    //new
    private float seaLevelMax = 20;

    [SerializeField]
    private float seaLevel = 10;
    [SerializeField]
    private int date = 0;

    //new
    [SerializeField]
    private int speedSeaLevel = 0; //la vitesse pour controller le sealevel augmenter ou desendre

    public Vaisseau Vaisseau { get => vaisseau; set => vaisseau = value; }
    public Carte Carte { get => carte; set => carte = value; }
    public Destination JoueurDestination { get => joueurDestination; set => joueurDestination = value; }
    public float SeaLevel  { get => seaLevel; set => seaLevel = value; }
    public int Date { get => date; set => date = value; }


    private void Awake()
    {
        Debug.Assert(GameManager.Instance == null);
        GameManager.Instance = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void InitCarte()
    {
        //TODO
    }
    
    //auto?? a discuter
   void UpdateSeaLevel()
    {
        //TODO
        //normal
        //SeaLevel -= speedSeaLevel * Time.deltaTime;
        //if (SeaLevel < 0)
          //  Debug.Log("WIN!");
        //punir
        //SeaLevel += speedSeaLevel * Time.deltaTime;
        //if (SeaLevel > 0)
        //        Debug.Log("LOSE!");
    }

    /*
     *@param nombre Ajouter combien de jour pour la date 
     */

    void UpdateDate(int nombre)
    {
        date += nombre;
    }

}
