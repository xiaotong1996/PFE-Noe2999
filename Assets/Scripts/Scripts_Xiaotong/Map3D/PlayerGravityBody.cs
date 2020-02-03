using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Associate PlanetScript and ship's transform. And keep attracting the ship.
/// </summary>
public class PlayerGravityBody : MonoBehaviour
{

    public PlanetScript attractorPlanet;
    private Transform playerTransform;

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;
    }

    void FixedUpdate()
    {
        if (attractorPlanet)
        {
            attractorPlanet.Attract(playerTransform);
        }
    }
}
