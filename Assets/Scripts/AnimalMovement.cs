using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Create animal's random move within a certain range
/// </summary>
public class AnimalMovement : MonoBehaviour
{
    // move speed
    public float speed = 1f;
    // move direction
    public Vector2 dir;
    // timer to decide move  or stop move
    public float timer;
    // animal is moving or not
    public bool isMove;
    

    void Start()
    {
        speed = 0.3f;
        // give a random direction
        dir = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        timer = 0;
        isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsSleep)
        {
            timer += Time.deltaTime;
            if (timer > 2.5)
            {
                // change animal's statement (move or not)
                ChangeState();
            }

            if (isMove)
            {
                Vector2 tmp = dir.normalized * speed * Time.deltaTime;
                transform.localPosition += new Vector3(tmp.x, tmp.y, 0);
            }
            // if the animal is in the room, change the speed 
            if (GetComponent<EtreVivant>().PositionSalle != null)
            {
                speed = 0.3f;
            }
        }
    }

    /// <summary>
    /// To change animal's statement (move or not) in a random way each 2.5s
    /// </summary>
    void ChangeState()
    {
        int value = Random.Range(0, 2);
        if(value == 0)
        {
            isMove = false;

        }
        else
        {
            if(!isMove)
            {
                dir = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
                isMove = true;
            }
            
        }

        timer = 0;
    }
    
    
    private void OnTriggerExit2D(Collider2D collision)
    {

        ///<summary>
        ///Try not let the animals move out of the colliders
        ///</summary> 
        if ( collision.tag == "Salle")
        {
            //dir.x = dir.x > 0 ? Random.Range(-10, 0) : Random.Range(0, 10);
            //dir.y = dir.y > 0 ? Random.Range(-10, 0) : Random.Range(0, 10);
            dir *= -1;
        }
        else if(collision.tag == "Ile" )
        {
            dir = collision.GetComponent<LoadBackground>().centrePoint.transform.position - transform.position;
        }

    }

}
