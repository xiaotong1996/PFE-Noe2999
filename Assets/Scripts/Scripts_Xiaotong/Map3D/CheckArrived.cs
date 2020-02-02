using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckArrived : MonoBehaviour
{
    private bool isArrived;
    private bool isOnLand;
    private string islandStayName;
    private GameObject destinationStay;
    //public ShowIslandInfo sii;

    public MoveOnEarth moveOnEarth;
    public bool IsArrived { get => isArrived; set => isArrived = value; }
    public bool IsOnLand { get => isOnLand; set => isOnLand = value; }
    public string IslandStayName { get => islandStayName; set => islandStayName = value; }
    public GameObject DestinationStay { get => destinationStay; set => destinationStay = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Destination>().Name.Equals( moveOnEarth.IslandChosenName))
        {
            Debug.Log(moveOnEarth.IslandChosenName);
            IsArrived = true;
            DestinationStay = other.gameObject;
            if(DestinationStay!=null)
            IslandStayName = other.gameObject.GetComponent<Destination>().Name;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Destination>().Name.Equals( IslandStayName))
        {
            IsArrived = false;
            IsOnLand = false;
            IslandStayName = null;
            DestinationStay = null;
            //sii.lol = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        IsArrived = false;
        IsOnLand = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(IsOnLand);
        if (IsArrived&&!IsOnLand)
        {
            // arrived show island scene
            // TODO
            moveOnEarth.IsMove = false;
            SceneManager.LoadScene("vaiseau_Ile");
            IsOnLand = true;
            print(gameObject.name);
        }
    }
}
