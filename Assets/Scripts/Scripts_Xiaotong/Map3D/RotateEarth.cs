using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    public float rotationSpeed = 8;  //This will determine max rotation speed, you can adjust in the inspector
    Ray r;
    RaycastHit rh;
    public MoveOnEarth moveOnEarth;
    public ShowIslandInfo sii;

    void Update()
    {
        if (sii == null && SceneDataModel.curscene == "Map3D") sii = GameObject.Find("Canvas").GetComponent<ShowIslandInfo>();
        
        //If you want to prevent rotation, just don't call this method
        if(!GameManager.Instance.IsSleep)
            RotateObject();
    }

    void RotateObject()
    {
        r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out rh, 1000))
        {
            if (rh.collider.gameObject.tag == "Earth" && !moveOnEarth.IsMove && !sii.lol)
            {
                if (Input.GetMouseButton(0))
                {
                    transform.Rotate((Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * rotationSpeed * -Time.deltaTime), 0, Space.World);
                }
            }
        }
    }
}
