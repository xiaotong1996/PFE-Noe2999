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

    [SerializeField]
    private int seaLevel = 10;
    [SerializeField]
    private int date = 0;

    public Vaisseau Vaisseau { get => vaisseau; set => vaisseau = value; }
    public Carte Carte { get => carte; set => carte = value; }
    public Destination JoueurDestination { get => joueurDestination; set => joueurDestination = value; }

    public  int SeaLevel  { get => seaLevel; set => seaLevel = value; }
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

}
