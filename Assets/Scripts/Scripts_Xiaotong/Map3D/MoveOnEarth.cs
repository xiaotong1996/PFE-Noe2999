using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnEarth : MonoBehaviour
{
    private Vector3 desPos;
    private bool isMove;//是否移动
    private Vector3 currentPos;
    private RaycastHit hit;
    public GameObject sphere;

    public bool IsMove { get => isMove; set => isMove = value; }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000, 1 << 9))
            {
                if (hit.transform.tag == "Island"&&!IsMove)
                {
                    desPos = hit.point;
                    IsMove = true;
                    Debug.Log("start moving");
                }
            }
        }
        if (IsMove)
        {
            //获取每帧移动时当前的点
            currentPos = Vector3.MoveTowards(transform.position, desPos, 0.1f);
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
            Debug.Log(Vector3.Distance(transform.position, desPos));
            if (Vector3.Distance(transform.position, desPos) < 5f)
            {
                IsMove = false;
                // arrived show island scene
                // TODO
            }
        }
    }

}
