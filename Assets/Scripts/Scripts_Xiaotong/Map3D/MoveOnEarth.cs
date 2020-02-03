using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// MoveOnEarth is used to make ship model move on the surface of the Earth.
/// </summary>
public class MoveOnEarth : MonoBehaviour
{
    private Vector3 desPos;
    private bool isMove;
    private Vector3 currentPos;
    private RaycastHit hit;
    public GameObject sphere;

    [SerializeField]
    private float energyConsomePerFrame = 1;

    [SerializeField]
    private float speed = 0.5f;

    private string islandChosenName;

    public bool IsMove { get => isMove; set => isMove = value; }
    public string IslandChosenName { get => islandChosenName; set => islandChosenName = value; }
    public float Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        IsMove = false;
    }

    /// <summary>
    /// If ship is already reached an island, player clicks this island will enter the island.
    /// If not, this island will be set as the destination.
    /// </summary>
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Island" && !IsMove)
            {

                IslandChosenName = hit.transform.gameObject.GetComponent<Destination>().Name;
                var islandStayName = GetComponent<CheckArrived>().IslandStayName;

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

            if (IsMove && GameManager.Instance.Energie >= 3)
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

    /// <summary>
    /// Change ship move state.
    /// </summary>
    public void ChangeIsMove()
    {
        IsMove = true;
    }

    /// <summary>
    /// With the use of Physique enginee, a very simple method to move ship arround a sphere.
    /// </summary>
    void Move()
    {
        transform.LookAt(desPos, transform.up);
        transform.Rotate(new Vector3(0, 90, 0));
        transform.position = Vector3.Lerp(transform.position, desPos, Time.deltaTime * speed);
    }

}
