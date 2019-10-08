using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle : MonoBehaviour
{
    [SerializeField]
    private EtatsPossiblesSalle salleEtat;
    public EtatsPossiblesSalle SalleEtat { get => salleEtat; set => salleEtat = value; }

    [SerializeField]
    private int taille;
    public int Taille { get => taille; set => taille = value; }

}

