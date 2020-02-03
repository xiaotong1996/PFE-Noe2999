using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergieEffect : MonoBehaviour
{
    public Transform destination;
    
    public float acceleration;
    public float vitesse;
    public float vitesseMAX;
    public GameObject canvas;
    //public GameObject heart;
    private Vector2 direction;
    private Vector2 Test;
    private bool okX;
    private bool okY;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        destination = GameObject.Find("EnergieEffectDestination").transform;

        if (destination.transform.position.x < transform.position.x) direction.x = -1;
        else direction.x = 1;

        if (destination.transform.position.y < transform.position.y) direction.y = -1;
        else direction.y = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != destination.transform.position.x || transform.position.y != destination.transform.position.y)
        {
            if (vitesse != vitesseMAX)
            {
                vitesse += acceleration * Time.deltaTime;
                if (vitesse > vitesseMAX) vitesse = vitesseMAX;
            }

            float newPosX = transform.position.x + vitesse * Time.deltaTime * direction.x;
            float newPosY = transform.position.y + vitesse * Time.deltaTime * direction.y;
            Test.x = newPosX;
            Test.y = newPosY;


            if ((transform.position.x > destination.position.x && newPosX < destination.position.x) || (transform.position.x < destination.position.x && newPosX > destination.position.x) || okX)
            {
                okX = true;
                newPosX = destination.transform.position.x;
            }


            if ((transform.position.y > destination.position.y && newPosY < destination.position.y) || (transform.position.y < destination.position.y && newPosY > destination.position.y) ||okY)
            {
                okY = true;
                newPosY = destination.transform.position.y;
            }

            transform.position = new Vector3(newPosX, newPosY, transform.position.z);
        }

        else Destroy(gameObject);

        //if (transform.position.x > 100 || transform.position.x < 100 || transform.position.y > 100 || transform.position.y < 100) Destroy(gameObject);

    }


}
