using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : EtreVivant
{
   public Chat(int _joursVecus) 
    {
        vaisseau = FindObjectOfType<Vaisseau>();
        JoursVecus = _joursVecus;
        EstMature = false;
        PeriodeDepuisEnCouple = 0;
        EnCouple = false;
        EnCoupleAvec = null;
        float randomfloat = Random.Range(0.0f, 1.0f);
        //Sexe est définis aléatoirement
        if (randomfloat > 0.5f)
        {
            Sexe = EnumSexe.MALE;
        }
        else
        {
            Sexe = EnumSexe.FEMELLE;
        }
        description = "Ne s'entend pas avec les chiens ! [Vous ne pouvez pas le placer dans la même salle qu'un chien]";
        Taille = 2;
        NourritureConsommee = 5;
        NourritureFavorite = NourritureType.NOURRITUREVIANDE;
        PeriodeDeVie = 3000;
        JoursAvantMaturite = 1000;
        PeriodeDeReproduction = 70;
        EcosystemeFavorit = EcosystemeType.PLAINE;
        Race = EnumRace.CHAT;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.CHIEN);
        if (_joursVecus >= JoursAvantMaturite)
        {
            EstMature = true;
        }
    }
}
