using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleEmbarquement : Salle
{
    [SerializeField]
    private List<EtreVivant> animaux;
    public List<EtreVivant> Animaux { get => animaux; set => animaux = value; }
}
