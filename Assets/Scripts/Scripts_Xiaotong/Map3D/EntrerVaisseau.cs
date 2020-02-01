using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrerVaisseau : MonoBehaviour
{

    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
