using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : EtreVivant
{
    //public Lion(EnumSexe sexe)
    //{
    //    vaisseau = FindObjectOfType<Vaisseau>();
    //    EnCouple = false;
    //    EnCoupleAvec = null;
    //    Sexe = sexe;
    //    description = "Mange les poules !! [Vous ne pouvez pas le placer dans la même salle qu'une poule]";
    //    NourritureFavorite = NourritureType.STEAK;
    //    NourritureMangeable = new List<NourritureType>();
    //    NourritureMangeable.Add(NourritureType.OSVIANDE);
    //    NourritureMangeable.Add(NourritureType.POISSON);
    //    EcosystemeFavorit = EcosystemeType.SAVANE;
    //    Race = EnumRace.LION;
    //    AnimauxDetestes = new List<EnumRace>();
    //    AnimauxDetestes.Add(EnumRace.POULE);
    //    Chronometre = 0;
    //    Estomac = 10f;
    //    Fatigue = 10f;
    //    Chronolimite = 25 + Random.Range(0.0f, 10.0f);
    //}

    private void Awake()
    {
        //vaisseau = FindObjectOfType<Vaisseau>();
        EnCouple = false;
        EnCoupleAvec = null;
        description = "Mange les poules !! [Vous ne pouvez pas le placer dans la même salle qu'une poule]";
        NourritureFavorite = NourritureType.STEAK;
        NourritureMangeable = new List<NourritureType>();
        NourritureMangeable.Add(NourritureType.OSVIANDE);
        NourritureMangeable.Add(NourritureType.POISSON);
        EcosystemeFavorit = EcosystemeType.SAVANE;
        Race = EnumRace.LION;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.POULE);
        Chronometre = 0;
        Estomac = 10f;
        Fatigue = 10f;
        Chronolimite = 25 + UnityEngine.Random.Range(0.0f, 10.0f);
        Id = Guid.NewGuid().ToString("N");
        Debug.Log("ID");
    }
}