using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zebre : EtreVivant
{
    public Zebre()
    {
        description = "Se fait bouffer par les lions ! [Vous ne pouvez pas le placer dans la même salle qu'un lion";
        NourritureConsommee = 5;
        NourritureFavorite = NourritureType.NOURRITUREVEG;
        PeriodeDeVie = 3000;
        JoursVecus = 0;
        PeriodeDeReproduction = 90;
        PeriodeDepuisEnCouple = 0;
        EcosystemeFavorit = EcosystemeType.SAVANE;
        Race = EnumRace.ZEBRE;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.LION);
        EnCouple = false;
        //il faut aussi définir le sexe
    }
}
