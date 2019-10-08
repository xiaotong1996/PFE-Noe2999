using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleRessources : Salle
{
    [SerializeField]
    private TypeDeRessource ressourceType;
    public TypeDeRessource RessourceType { get => ressourceType; set => ressourceType = value; }
}
