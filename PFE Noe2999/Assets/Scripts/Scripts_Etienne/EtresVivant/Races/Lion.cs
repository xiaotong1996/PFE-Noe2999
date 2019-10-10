using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : EtreVivant
{
    protected override void Start()
    {
        base.Start();
        description = "Mange les poules !! [Vous ne pouvez pas le placer dans la même salle qu'une poule]";
        Taille = 6;
        NourritureConsommee = 10;
        NourritureFavorite = NourritureType.NOURRITUREVIANDE;
        PeriodeDeVie = 5000;
        JoursVecus = 0;
        PeriodeDeReproduction = 120;
        PeriodeDepuisEnCouple = 0;
        EcosystemeFavorit = EcosystemeType.SAVANE;
        Race = EnumRace.LION;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.POULE);
        EnCouple = false;
        //il faut aussi définir le sexe
    }
}