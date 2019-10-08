using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chien : EtreVivant
{
    public Chien()
    {
        description = "Ne s'entend pas avec les chats ! [Vous ne pouvez pas le placer dans la même salle qu'un chat]";
        NourritureConsommee = 5;
        NourritureFavorite = NourritureType.NOURRITUREVIANDE;
        PeriodeDeVie = 3600;
        JoursVecus = 0;
        PeriodeDeReproduction = 70;
        PeriodeDepuisEnCouple = 0;
        EcosystemeFavorit = EcosystemeType.PLAINE;
        Race = EnumRace.CHIEN;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.CHAT);
        EnCouple = false;
        //il faut aussi définir le sexe
    }
}