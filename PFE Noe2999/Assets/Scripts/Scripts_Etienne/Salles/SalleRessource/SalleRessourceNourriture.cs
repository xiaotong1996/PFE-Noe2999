using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleRessourceNourriture : Salle
{

    public SalleRessourceNourriture()
    {
        SalleEtat = EnumEtatsPossiblesSalle.AMENAGEE;
        SalleType = EnumSalleType.STOCKNOURRITURE;
    }
}
