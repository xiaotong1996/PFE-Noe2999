using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleRessourceEnergie : Salle
{

    public SalleRessourceEnergie()
    {
        SalleEtat = EnumEtatsPossiblesSalle.AMENAGEE;
        SalleType = EnumSalleType.STOCKENERGIE;
    }
}
