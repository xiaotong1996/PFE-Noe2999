using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDraggable : MonoBehaviour
{
    public bool draggable = false;

    public GameObject parent { get { return _parent; } }

    public GameObject _parent;
    public Vector2 originalPosition;
    public GameObject container;
    public Camera camera;
    private EtreVivant animal;
    private int destination = -1; // -1-> no destination  0->room    1->island

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();
        animal = GetComponent<EtreVivant>();
        //Debug.Assert(animal == null);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        //Debug.Log("down1");
        //if(draggable)
        //{ 
        if(!AnimalDataModel.isPause)
            originalPosition = transform.position;
           // Debug.Log("down");
        //}
    }

    private void OnMouseDrag()
    {
        //if (camera==null)
        //{
        //    Debug.Log("nulllllllllllllllllll");
        //}
        //else
        //{
        //Debug.Log(gameObject.name);
        if (!AnimalDataModel.isPause)
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,-0.5f);
        
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!AnimalDataModel.isPause)
        {
            if (collision.gameObject == container)
            {
                container = null;
                //Debug.Log("exit");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.GetComponent<OnDraggable>() != null)
        //{
        //if (!collision.gameObject.GetComponent<OnDraggable>().draggable)
        if (!AnimalDataModel.isPause)
        {
            //Debug.Log("aaaaaaaaaaaaaa" + collision.tag);
            if (collision.GetComponent<SalleAnimaux>() != null)
            {
                container = collision.gameObject;
                destination = 0;
                //Debug.Log("enter");
            }
            else if (collision.tag == "Ile")
            {
                container = collision.gameObject;
                destination = 1;
            }
        }
    }

    private void OnMouseUp()
    {
        //Debug.Log("Up");
        if (!AnimalDataModel.isPause)
        {
            if (container == null && draggable)
            {

                transform.position = new Vector3(originalPosition.x, originalPosition.y, -0.5f);
                container = null;
            }
            else if (container != null)
            {

                //Debug.Log(s.SalleType);
                //Debug.Log(gameObject.tag);


                // move an animal to a room
                if (destination == 0)
                {
                    SalleAnimaux s = container.GetComponent<SalleAnimaux>();

                    if (gameObject.GetComponent<EtreVivant>().CanInThisRoom(s))
                    {
                        transform.SetParent(container.transform);
                        _parent = container;
                        container = null;

                        if (animal.PositionSalle != null) // animal is in a room on the boat
                        {
                            //salle ver salle 
                            bool state = animal.DeplacerEtreVivant(animal.PositionSalle, s);
                            Debug.Log("salle to salle " + s.name + " " + s.Animaux.Count);
                            if (!state)
                            {
                                transform.position = new Vector3(originalPosition.x, originalPosition.y, -0.5f);
                                container = null;
                            }


                        }
                        else // animal is on an island
                        {
                            //destination ver salle
                            bool state = animal.DeplacerEtreVivant(animal.PositionDestination, s);
                            Debug.Log("des to salle " + s.name + " " + s.SalleType + " " + s.Animaux.Count);
                            if (!state)
                            {
                                transform.position = new Vector3(originalPosition.x, originalPosition.y, -0.5f);
                                container = null;
                            }
                        }

                        Debug.Log("count " + AnimalDataModel.GetDataModel().Count);
                        Debug.Log("count " + gameObject.name + " " + gameObject.GetComponent<EtreVivant>().Id);
                    }
                    else
                    {
                        transform.position = new Vector3(originalPosition.x, originalPosition.y, -0.5f);
                        container = null;
                    }
                }
                else if (destination == 1 && animal.PositionSalle != null)
                {
                    Destination s = GameManager.Instance.JoueurDestination.GetComponent<Destination>();
                    transform.SetParent(null);
                    _parent = container;
                    container = null;
                    bool state = animal.DeplacerEtreVivant(animal.PositionSalle, s);

                    if (!state)
                    {

                        transform.position = new Vector3(originalPosition.x, originalPosition.y, -0.5f);
                        container = null;
                    }
                    else
                    {
                        Debug.Log("count " + AnimalDataModel.GetDataModel().Count);
                        if (s.Ecosysteme.EcosystemeType == animal.EcosystemeFavorit)
                        {
                            //TODO do something
                        }
                    }

                }
                else
                {
                    transform.position = new Vector3(originalPosition.x, originalPosition.y, -0.5f);
                    container = null;
                }
            }
        }

    }
}
