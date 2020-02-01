using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleAnimaux : Salle
{
    [SerializeField]
    private int tailleOcuppee;
    public int TailleOcuppee { get => tailleOcuppee; set => tailleOcuppee = value; }

    [SerializeField]
    private List<EtreVivant> animaux;
    public List<EtreVivant> Animaux { get => animaux; set => animaux = value; }


    public SalleAnimaux()
    {
        //SalleEtat = EnumEtatsPossiblesSalle.AMENAGEE;
        //SalleType = EnumSalleType.NONE;
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    int temp = Random.Range(0, point.Count);//在第二步的随机点中随机选一个出来
    //    while (temp == collision.gameObject.GetComponent<AnimalMovement>().index)//这个随机点和前一个随机点不能相同，如果相同的话，就会直接出边界了。
    //    {
    //        temp = Random.Range(0, point.Count);
    //    }
    //    collision.gameObject.GetComponent<AnimalMovement>().dir = point[temp].position - collision.transform.position;//给游戏物体一个到随机点的方向，这个方向就是它接下来的运动方向。
    //    collision.gameObject.GetComponent<AnimalMovement>().index = temp;//记录当前随机点

    //}
}
