using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleEmbarquement : SalleAnimaux
{
    public SalleEmbarquement()
    {
        SalleEtat = EnumEtatsPossiblesSalle.AMENAGEE;
        SalleType = EnumSalleType.SALLEEMBARQUEMENT;
    }
}
