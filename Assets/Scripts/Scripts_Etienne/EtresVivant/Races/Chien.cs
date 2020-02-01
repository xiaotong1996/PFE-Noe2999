using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chien : EtreVivant
{
    //public Chien(EnumSexe sexe)
    //{
    //    vaisseau = FindObjectOfType<Vaisseau>();
    //    EnCouple = false;
    //    EnCoupleAvec = null;
    //    Sexe = sexe;
    //    description = "Ne s'entend pas avec les chats ! [Vous ne pouvez pas le placer dans la même salle qu'un chat]";
    //    EcosystemeFavorit = EcosystemeType.PLAINE;
    //    NourritureFavorite = NourritureType.OSVIANDE;
    //    NourritureMangeable = new List<NourritureType>();
    //    NourritureMangeable.Add(NourritureType.POISSON);
    //    NourritureMangeable.Add(NourritureType.STEAK);
    //    Race = EnumRace.CHIEN;
    //    AnimauxDetestes = new List<EnumRace>();
    //    AnimauxDetestes.Add(EnumRace.CHAT);
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
        description = "Ne s'entend pas avec les chats ! [Vous ne pouvez pas le placer dans la même salle qu'un chat]";
        EcosystemeFavorit = EcosystemeType.PLAINE;
        NourritureFavorite = NourritureType.OSVIANDE;
        NourritureMangeable = new List<NourritureType>();
        NourritureMangeable.Add(NourritureType.POISSON);
        NourritureMangeable.Add(NourritureType.STEAK);
        Race = EnumRace.CHIEN;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.CHAT);
        Chronometre = 0;
        Estomac = 10f;
        Fatigue = 10f;
        Chronolimite = 25 + UnityEngine.Random.Range(0.0f, 10.0f);
        Id = Guid.NewGuid().ToString("N");
        Debug.Log("ID");
    }
   
}