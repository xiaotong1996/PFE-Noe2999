using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleCuisine : Salle
{
    public SalleCuisine()
    {
        SalleEtat = EnumEtatsPossiblesSalle.AMENAGEE;
        SalleType = EnumSalleType.CUISINE;
    }
}
