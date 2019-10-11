using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zebre : EtreVivant
{
    public Zebre(int _joursVecus)
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
        description = "Se fait bouffer par les lions ! [Vous ne pouvez pas le placer dans la même salle qu'un lion";
        Taille = 5;
        NourritureConsommee = 5;
        NourritureFavorite = NourritureType.NOURRITUREVEG;
        PeriodeDeVie = 4000;
        JoursAvantMaturite = 1500;
        PeriodeDeReproduction = 90;
        EcosystemeFavorit = EcosystemeType.SAVANE;
        Race = EnumRace.ZEBRE;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.LION);
        if (_joursVecus >= JoursAvantMaturite)
        {
            EstMature = true;
        }
    }
}
