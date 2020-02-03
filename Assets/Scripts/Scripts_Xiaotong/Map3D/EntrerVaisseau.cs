using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// EntrerVaisseau allows player click ship model and enter the inner screen of the ship
/// </summary>
public class EntrerVaisseau : MonoBehaviour
{

    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000, 1 << 9))
            {
                if (hit.transform.tag == "Vaisseau")
                {
                    SceneManager.LoadScene("Vaisseau");
                }
            }
        }
    }
}
