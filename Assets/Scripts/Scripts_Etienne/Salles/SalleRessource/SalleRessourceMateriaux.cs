using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleRessourceMateriaux : Salle
{

    public SalleRessourceMateriaux()
    {
        SalleEtat = EnumEtatsPossiblesSalle.AMENAGEE;
        SalleType = EnumSalleType.STOCKMATERIAUX;
    }
}