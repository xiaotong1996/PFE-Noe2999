using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : EtreVivant
{
    public Chat()
    {
        description = "Ne s'entend pas avec les chiens ! [Vous ne pouvez pas le placer dans la même salle qu'un chien]";
        NourritureConsommee = 5;
        NourritureFavorite = NourritureType.NOURRITUREVIANDE;
        PeriodeDeVie = 3000;
        JoursVecus = 0;
        PeriodeDeReproduction = 70;
        PeriodeDepuisEnCouple = 0;
        EcosystemeFavorit = EcosystemeType.PLAINE;
        Race = EnumRace.CHAT;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.CHIEN);
        EnCouple = false;
        //il faut aussi définir le sexe
    }
}
