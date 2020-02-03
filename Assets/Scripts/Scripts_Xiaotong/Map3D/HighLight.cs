using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HighLight is used when player chooses an island. It will make this island show in highlight.
/// </summary>
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
