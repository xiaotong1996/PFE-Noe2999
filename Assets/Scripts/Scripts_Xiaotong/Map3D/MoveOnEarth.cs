using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveOnEarth : MonoBehaviour
{
    private Vector3 desPos;
    private bool isMove;
    private Vector3 currentPos;
    private RaycastHit hit;
    public GameObject sphere;

    [SerializeField]
    private float energyConsomePerFrame=1;
    

    [SerializeField]
    private float speed=0.5f;

    private string islandChosenName;

    public bool IsMove { get => isMove; set => isMove = value; }
    public string IslandChosenName { get => islandChosenName; set => islandChosenName = value; }
    public float Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        IsMove = false;
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Island" && !IsMove)
            {

                IslandChosenName = hit.transform.gameObject.GetComponent<Destination>().Name;
                var islandStayName = GetComponent<CheckArrived>().IslandStayName;

                //Debug.Log(IslandChosenName);
                //Debug.Log(islandStayName);

                if (islandStayName != null && islandStayName.Equals(IslandChosenName) && GetComponent<CheckArrived>().IsOnLand)
                {
                    GetComponent<CheckArrived>().IsArrived = true;
                    SceneManager.LoadScene("vaiseau_Ile");
                }
                else
                {
                    desPos = hit.point;
                    //GetComponent<CheckArrived>().IsOnLand = false;
                    GetComponent<CheckArrived>().IsArrived = false;
                }

            }
        }
    }
    


    void Update()
    {
        if (!GameManager.Instance.IsSleep)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Island" && !IsMove)
                    {

                        IslandChosenName = hit.transform.gameObject.GetComponent<Destination>().Name;
                        var islandStayName = GetComponent<CheckArrived>().IslandStayName;

                        //Debug.Log(IslandChosenName);
                        //Debug.Log(islandStayName);

                        if (islandStayName != null && islandStayName.Equals(IslandChosenName) && GetComponent<CheckArrived>().IsOnLand)
                        {
                            GetComponent<CheckArrived>().IsArrived = true;
                            SceneManager.LoadScene("vaiseau_Ile");
                        }
                        else
                        {
                            desPos = hit.point;
                            //GetComponent<CheckArrived>().IsOnLand = false;
                            GetComponent<CheckArrived>().IsArrived = false;
                        }

                    }
                }
            }

            if (IsMove&&GameManager.Instance.Energie>=3)
            {
                Move();
                gameObject.GetComponent<CheckArrived>().IsOnLand = false;
                GameManager.Instance.ConsommerEnergie(energyConsomePerFrame * Time.deltaTime);
            }
            else
            {
                //gameObject.GetComponent<CheckArrived>().IsOnLand = true;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }

    public void ChangeIsMove()
    {
        IsMove = true;
    }

    void Move()
    {
        //var targetRotation = Quaternion.LookRotation(desPos,transform.right);
        //transform.rotation = targetRotation;
        transform.LookAt(desPos,transform.up);
        transform.Rotate(new Vector3(0, 90, 0));

        transform.position = Vector3.Lerp(transform.position, desPos, Time.deltaTime * speed);
    }

   
    void MoveMethod3(GameObject player, GameObject world)
    {
        // stash the original player position & velocity
        Vector3 originalPos = player.transform.position;
        Vector3 originalVel = player.GetComponent<Rigidbody>().velocity;

        // ordinary linear motion.
        // maybe this is done w/ unity physics instead. up to you.
        //player.transform.position += player.GetComponent<Rigidbody>().velocity * dT;
        MoveMethod2();

        // vector from the center of the world to the player position.
        // if the world is centered at 0, 0, 0, then this is just player.position.
        Vector3 worldCenterToPlayer = player.transform.position - world.transform.position;

        // scale that vector so that its the size of the sphere
        Vector3 constrainedPosition = worldCenterToPlayer.normalized * 50;

        // and offset it by the center of the world again.
        // if the world is at 0,0,0 this can be skipped.
        player.transform.position = world.transform.position + constrainedPosition;

        // okay, now the player position is on the surface.
        // let's deal with conserving surface velocity.
        // the goal of this section of code is to create a new velocity vector which:
        // 1. has the same magnitude as the original velocity
        // 2. is tangent to the sphere
        // 3. is going in the same direction, more or less, as the original velocity.

        // create a vector which is perpendicular to both the vector from the center of the world to the player
        // and also to the original velocity:
        Vector3 perpAxis = Vector3.Cross(worldCenterToPlayer, originalVel);

        // create a vector which is perpendicular to both our 'axis' vector and the radius vector.
        // this vector is going in the direction we want, but is likely the wrong size.
        Vector3 tangent = Vector3.Cross(perpAxis, worldCenterToPlayer);

        // re-scale the tangent vector so it's the same magnitude as the original.
        player.transform.position = tangent.normalized * originalVel.magnitude;
    }


    void MoveMethod2()
    {
        float gravityForce = 1;
        Vector3 gravityDirection = Vector3.Normalize(desPos-transform.position);
        GetComponent<Rigidbody>().AddForce(gravityDirection * gravityForce);
    }

    void MoveMethod1()
    {
        //获取每帧移动时当前的点
        currentPos = Vector3.MoveTowards(transform.position, desPos, Speed);
        //Debug.Log(currentPos);
        //每帧发射的射线
        Ray rayEveryFrame = new Ray(Camera.main.transform.localPosition, (currentPos - Camera.main.transform.localPosition).normalized);
        //发射射线
        if (Physics.Raycast(rayEveryFrame, out hit, 1000, 1 << 8))
        {
            //求当前点的法线
            Vector3 normal = (transform.position - sphere.transform.position).normalized;
            //次切线
            Vector3 binormal = Vector3.Cross(normal, desPos - sphere.transform.position).normalized;
            //切线
            Vector3 tangent = Vector3.Cross(binormal, normal).normalized;
            transform.parent.position = hit.point;
            transform.parent.up = normal;
            //计算父级物体正方向和切线的夹角
            float angle = Vector3.Angle(transform.parent.right, tangent);
            //将子物体的方向矫正
            //要分在物体上方点击还是下方点击来判断子物体应该往那边偏移
            if (transform.position.x < sphere.transform.position.x)
            {
                if (desPos.y > transform.position.y)
                {
                    transform.localEulerAngles = new Vector3(0, transform.parent.localEulerAngles.y - angle, 0);
                    //transform.rotation = transform.rotation * Quaternion.Euler(0, 90, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(0, transform.parent.localEulerAngles.y + angle, 0);
                    //transform.rotation = transform.rotation * Quaternion.Euler(0, 90, 0);
                }
            }
            else
            {
                if (desPos.y > transform.position.y)
                {
                    transform.localEulerAngles = new Vector3(0, transform.parent.localEulerAngles.y + angle, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(0, transform.parent.localEulerAngles.y - angle, 0);
                }
            }

        }

        //var vaisseau = GetComponent<Vaisseau>();
        //if (vaisseau != null)
        //{
        //    vaisseau.ConsommerEnergie(1);
        //}
    }

}
