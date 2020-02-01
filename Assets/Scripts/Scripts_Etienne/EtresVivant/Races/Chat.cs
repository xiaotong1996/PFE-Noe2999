using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : EtreVivant
{
    
   //public Chat(EnumSexe sexe) 
   // {
        
   //     vaisseau = FindObjectOfType<Vaisseau>();
   //     EnCouple = false;
   //     EnCoupleAvec = null;
   //     Sexe = sexe;
   //     description = "Ne s'entend pas avec les chiens ! [Vous ne pouvez pas le placer dans la même salle qu'un chien]";
   //     NourritureFavorite = NourritureType.POISSON;
   //     NourritureMangeable = new List<NourritureType>();
   //     NourritureMangeable.Add(NourritureType.OSVIANDE);
   //     NourritureMangeable.Add(NourritureType.STEAK);
   //     EcosystemeFavorit = EcosystemeType.PLAINE;
   //     Race = EnumRace.CHAT;
   //     AnimauxDetestes = new List<EnumRace>();
   //     AnimauxDetestes.Add(EnumRace.CHIEN);
   //     Chronometre = 0;
   //     Estomac = 10f;
   //     Fatigue = 10f;
   //     Chronolimite = 25 + Random.Range(0.0f, 10.0f);
   // }


    private void Awake()
    {
        //vaisseau = FindObjectOfType<Vaisseau>();
        EnCouple = false;
        //EstEnTrainDeDormir = false;
        EnCoupleAvec = null;
        description = "Ne s'entend pas avec les chiens ! [Vous ne pouvez pas le placer dans la même salle qu'un chien";
        NourritureFavorite = NourritureType.POISSON;
        NourritureMangeable = new List<NourritureType>();
        NourritureMangeable.Add(NourritureType.OSVIANDE);
        NourritureMangeable.Add(NourritureType.STEAK);
        EcosystemeFavorit = EcosystemeType.PLAINE;
        Race = EnumRace.CHAT;
        AnimauxDetestes = new List<EnumRace>();
        AnimauxDetestes.Add(EnumRace.CHIEN);
        Chronometre = 0;
        Estomac = 10f;
        Fatigue = 10f;
        Chronolimite = 25 + UnityEngine.Random.Range(0.0f, 10.0f);
        Id = Guid.NewGuid().ToString("N");
        Debug.Log("ID");
    }


   


}
