using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poule : EtreVivant
{
    //public Poule(EnumSexe sexe)
    //{
    //    vaisseau = FindObjectOfType<Vaisseau>();
    //    EnCouple = false;
    //    EnCoupleAvec = null;
    //    Sexe = sexe;
    //    description = "Se fait bouffer par les lions ! [Vous ne pouvez pas le placer dans la même salle qu'un lion]";
    //    NourritureFavorite = NourritureType.GRAINES;
    //    NourritureMangeable = new List<NourritureType>();
    //    NourritureMangeable.Add(NourritureType.HERBE);
    //    EcosystemeFavorit = EcosystemeType.PLAINE;
    //    //Race = EnumRace.POULE;
    //    AnimauxDetestes = new List<EnumRace>();
    //    AnimauxDetestes.Add(EnumRace.LION);
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
        description = "Se fait bouffer par les lions ! [Vous ne pouvez pas le placer dans la même salle qu'un lion]";
        NourritureFavorite = NourritureType.GRAINES;
        NourritureMangeable = new List<NourritureType>();
        NourritureMangeable.Add(NourritureType.HERBE);
        EcosystemeFavorit = EcosystemeType.PLAINE;
        Race = EnumRace.POULE;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.LION);
        Chronometre = 0;
        Estomac = 10f;
        Fatigue = 10f;
        Chronolimite = 25 + UnityEngine.Random.Range(0.0f, 10.0f);
        Id = Guid.NewGuid().ToString("N");
        //Debug.Log("ID");
    }
}
