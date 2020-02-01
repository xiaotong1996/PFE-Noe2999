using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFlag : MonoBehaviour
{

    public GameObject flagPrefab;

    private GameObject flag;
    // Start is called before the first frame update
    void Start()
    {
        flagPrefab = Resources.Load<GameObject>("Prefabs/UI/Map/flag_med");
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        var vaisseau = GameObject.FindGameObjectWithTag("Vaisseau");
        if (vaisseau != null)
        {
            var IslandChosenName = vaisseau.GetComponent<MoveOnEarth>().IslandChosenName;
            if (IslandChosenName == GetComponent<Destination>().Name)
            {
                if (flag == null)
                {
                    flag = Instantiate(flagPrefab, transform, false);
                }
            }
            else
            {
                if (flag != null)
                {
                    Destroy(flag);
                }
            }
        }
    }
}
