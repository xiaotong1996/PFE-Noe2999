using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleNaissance : SalleAnimaux
{
    public SalleNaissance()
    {
        SalleEtat = EnumEtatsPossiblesSalle.AMENAGEE;
        SalleType = EnumSalleType.SALLENAISSANCE;
    }
}
