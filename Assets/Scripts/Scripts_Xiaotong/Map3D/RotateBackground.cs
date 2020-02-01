using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackground : MonoBehaviour
{
    public Transform SunDestionation;
    //private int currentState = 0;//0 is day, 1 is night

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float sunIntensity;

    private Light sunLight;

    private Vector3 initPosition;
    private void Awake()
    {
        sunLight = transform.GetChild(0).GetComponent<Light>();
        initPosition = transform.position;
    }

    void Update()
    {
        if (GameManager.Instance.IsSleep)
        {
            transform.position = Vector3.MoveTowards(transform.position, SunDestionation.position, moveSpeed*Time.deltaTime);
            sunLight.intensity = sunLight.intensity < 0.001f? 0 : Mathf.Lerp(sunLight.intensity, 0.0f, 0.02f);
           
            //if(transform.position== SunDestionation.position) currentState = 1;
        }
        if (!GameManager.Instance.IsSleep)
        {
            transform.position = Vector3.MoveTowards(transform.position, initPosition, moveSpeed * Time.deltaTime);
            sunLight.intensity = sunLight.intensity > sunIntensity-0.01f ? sunIntensity : Mathf.Lerp(sunLight.intensity, sunIntensity, 0.02f);
            //if (transform.position == initPosition) currentState = 0;
        }
    }
}
