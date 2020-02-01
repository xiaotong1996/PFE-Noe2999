using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{

    public bool IsSelected = false; 
    private Material highLight;
    private Material normal;

   
    private RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        highLight = Resources.Load<Material>("Materials/Material_Earth_Selected");
        normal = Resources.Load<Material>("Materials/Material_Earth");

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.transform.tag == "Island")
        //        {
        //            IsSelected = true;
        //        }
        //        else
        //        {
        //            IsSelected = false;
        //        }
        //    }

        //    if (IsSelected)
        //    {
        //        if(hit.collider!=null)
        //        hit.collider.GetComponent<Renderer>().material = highLight;         
        //    }
        //    else
        //    {
        //        GetComponent<Renderer>().material = normal;
        //    }
        //}
        var vaisseau = GameObject.FindGameObjectWithTag("Vaisseau");
        if (vaisseau != null)
        {
            var IslandChosenName = vaisseau.GetComponent<MoveOnEarth>().IslandChosenName;
            if (IslandChosenName == GetComponent<Destination>().Name)
            {
                GetComponent<Renderer>().material = highLight;
            }
            else
            {
                GetComponent<Renderer>().material = normal;
            }
        }

    }
}
