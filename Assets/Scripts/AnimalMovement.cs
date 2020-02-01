using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public Vector2 dir;
    public int index;
    public float timer;
    public bool isMove;
    

    void Start()
    {
        speed = 0.3f;
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
                ChangeState();
            }

            if (isMove)
            {
                Vector2 tmp = dir.normalized * speed * Time.deltaTime;
                transform.localPosition += new Vector3(tmp.x, tmp.y, 0);
            }
            if (GetComponent<EtreVivant>().PositionSalle != null)
            {
                speed = 0.3f;
            }
        }
    }

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

        Debug.Log("Exit");
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
