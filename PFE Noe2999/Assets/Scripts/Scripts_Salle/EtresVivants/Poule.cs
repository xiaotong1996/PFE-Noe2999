using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poule : EtreVivant
{
    public Poule()
    {
        description = "Se fait bouffer par les lions ! [Vous ne pouvez pas le placer dans la même salle qu'un lion]";
        NourritureConsommee = 1;
        NourritureFavorite = NourritureType.NOURRITUREVEG;
        PeriodeDeVie = 1500;
        JoursVecus = 0;
        PeriodeDeReproduction = 20;
        PeriodeDepuisEnCouple = 0;
        EcosystemeFavorit = EcosystemeType.PLAINE;
        Race = EnumRace.POULE;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.LION);
        EnCouple = false;
        //il faut aussi définir le sexe
    }
}
