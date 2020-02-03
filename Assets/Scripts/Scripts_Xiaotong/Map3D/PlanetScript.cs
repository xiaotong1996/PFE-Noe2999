using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlanetScript is used to give Earth an appeal force to attract the ship.
/// </summary>
public class PlanetScript : MonoBehaviour
{

    public float gravity = -12;

    public void Attract(Transform playerTransform)
    {
        Vector3 gravityUp = (playerTransform.position - transform.position).normalized;
        Vector3 localUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
