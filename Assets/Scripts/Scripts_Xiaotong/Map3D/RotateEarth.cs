using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RotateEarth allows player to rotate the Earth.
/// </summary>
public class RotateEarth : MonoBehaviour
{
    public float rotationSpeed = 8;  //This will determine max rotation speed, you can adjust in the inspector
    Ray r;
    RaycastHit rh;
    public MoveOnEarth moveOnEarth;
    float mouseKeyTime = 0;

    void Update()
    {
        //If you want to prevent rotation, just don't call this method
        if (!GameManager.Instance.IsSleep)
            RotateObject();
    }

    /// <summary>
    /// mouseKeyTime is used to make player's input less sensible.
    /// </summary>
    void RotateObject()
    {
        r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out rh, 1000))
        {
            if (rh.collider.gameObject.tag == "Earth" && !moveOnEarth.IsMove)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    mouseKeyTime = 0;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    mouseKeyTime = 0;
                }

                if (Input.GetMouseButton(0))
                {
                    mouseKeyTime += Time.deltaTime;
                    if (mouseKeyTime > 0.15f)
                        transform.Rotate((Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * rotationSpeed * -Time.deltaTime), 0, Space.World);
                }

            }
        }
    }
}
