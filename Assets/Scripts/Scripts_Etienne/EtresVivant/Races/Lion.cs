using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : EtreVivant
{
    public Lion(int _joursVecus)
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
        description = "Mange les poules !! [Vous ne pouvez pas le placer dans la même salle qu'une poule]";
        Taille = 6;
        NourritureConsommee = 10;
        NourritureFavorite = NourritureType.NOURRITUREVIANDE;
        PeriodeDeVie = 5000;
        JoursAvantMaturite = 2500;
        PeriodeDeReproduction = 120;
        EcosystemeFavorit = EcosystemeType.SAVANE;
        Race = EnumRace.LION;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.POULE);
        if (_joursVecus >= JoursAvantMaturite)
        {
            EstMature = true;
        }
    }
}