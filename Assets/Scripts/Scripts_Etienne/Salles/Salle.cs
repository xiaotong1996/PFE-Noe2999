using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle : MonoBehaviour
{
    [SerializeField]
    private EnumEtatsPossiblesSalle salleEtat;
    public EnumEtatsPossiblesSalle SalleEtat { get => salleEtat; set => salleEtat = value; }

    [SerializeField]
    private int taille;
    public int Taille { get => taille; protected set => taille = value; }

    [SerializeField]
    private int numeroDeLaSalle;
    public int NumeroDeLaSalle { get => numeroDeLaSalle; protected set => numeroDeLaSalle = value; }

    [SerializeField]
    private int coutReparation;
    public int CoutReparation { get => coutReparation; protected set => coutReparation = value; }

    [SerializeField]
    private EnumSalleType salleType;
    public EnumSalleType SalleType { get => salleType; set => salleType = value; }

    public Salle()
    {
        SalleEtat = EnumEtatsPossiblesSalle.NONAMENAGEE;
    }
}

