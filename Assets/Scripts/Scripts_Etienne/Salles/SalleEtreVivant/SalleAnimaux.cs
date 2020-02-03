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

    public Transform centrePoint;

    public SalleAnimaux()
    {
        //SalleEtat = EnumEtatsPossiblesSalle.AMENAGEE;
        //SalleType = EnumSalleType.NONE;
    }

}
