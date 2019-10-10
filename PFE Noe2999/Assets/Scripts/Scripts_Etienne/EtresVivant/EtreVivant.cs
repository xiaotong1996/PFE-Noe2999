using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtreVivant : MonoBehaviour
{
    #region Déclaration des variables

    //la description de l'être vivant à afficher lorsque le joueur passe sa sourie dessus par exemple ; il faut aussi afficher les autres informations comme la duréedevie, nourriture, etc.
    public string description; 

    private Vaisseau vaisseau;

    [SerializeField]
    private int taille;
    public int Taille { get => taille; set => taille = value; }

    [SerializeField]
    private NourritureType nourritureFavorite;
    public NourritureType NourritureFavorite { get => nourritureFavorite; protected set => nourritureFavorite = value; }

    [SerializeField]
    private int nourritureConsommee;
    public int NourritureConsommee { get => nourritureConsommee; protected set => nourritureConsommee = value; }

    [SerializeField]
    private int periodeDeVie;
    public int PeriodeDeVie { get => periodeDeVie; protected set => periodeDeVie = value; }

    [SerializeField]
    private int joursVecus;
    public int JoursVecus { get => joursVecus; protected set => joursVecus = value; }

    [SerializeField]
    private int periodeDeReproduction;
    public int PeriodeDeReproduction { get => periodeDeReproduction; protected set => periodeDeReproduction = value; }

    [SerializeField]
    private int periodeDepuisEnCouple;
    public int PeriodeDepuisEnCouple { get => periodeDepuisEnCouple; protected set => periodeDepuisEnCouple = value; }

    [SerializeField]
    private EcosystemeType ecosystemeFavorit;
    public EcosystemeType EcosystemeFavorit { get => ecosystemeFavorit; protected set => ecosystemeFavorit = value; }
    
    //Ce booléen permet de savoir si l'etre vivant est sur une île qui est viable ; à ce moment là on peut considérer qu'il ne meurt plus puisque l'écosystème se régénere, il faut donc changer son état
    //en fait on pourrait même carrément le supprimer et l'ignorer lorsqu'il arrive dans un ecosysteme viable, à réfléchir
    [SerializeField]
    private bool estDansUnEcosystemeViable;
    public bool EstDansUnEcosystemeViable { get => estDansUnEcosystemeViable; set => estDansUnEcosystemeViable = value; }

    //Pour le moment j'ai mélangé animaux et êtres vivants, on peut imaginer plus tard de séparer les champs qui suivent pour les mettre dans animaux seulement
    [SerializeField]
    private int quantiteeDeViandeProduite; //pour quand on implémentera la cuisine
    public int QuantiteeDeViandeProduite { get => quantiteeDeViandeProduite; protected set => quantiteeDeViandeProduite = value; }

    [SerializeField]
    private EnumRace race;
    public EnumRace Race { get => race; protected set => race = value; }

    //Ce qui pourrait être chouette, c'est de n'avoir ce type de mécanique que pour quelques animaux (ex : chiens et chats qui se détestent et ne peuvent pas être dans la même salle
    //et d'avoir d'autres mécaniques pour les autres.
    [SerializeField] 
    private List<EnumRace> animauxDetestes;
    public List<EnumRace> AnimauxDetestes { get => animauxDetestes; protected set => animauxDetestes = value; }

    [SerializeField]
    private EnumSexe sexe;
    public EnumSexe Sexe { get => sexe; protected set => sexe = value; }

    [SerializeField]
    private bool enCouple;
    public bool EnCouple { get => enCouple; protected set => enCouple = value; }
    #endregion

    protected virtual void Start()
    {
        vaisseau = FindObjectOfType<Vaisseau>();
        //TODO : SetSex
    }
    #region méthodes 

    #region méthodes privées
    //Le joueur doit pouvoir appeler cette méthode n'importe quand pour pouvoir tuer un animal
    private void Mort()
    {
        Destroy(gameObject);
        //TODO?
    }

    private void Reproduction()
    {
        //TODO
        /*Type raceAnimal = this.GetType();
        raceAnimal nouveauNe;
        Debug.Log("Un {0} est né !", raceAnimal);
        SalleNaissance salleNaissance = FindObjectOfType<SalleNaissance>();
        salleNaissance.Animaux.Add(nouveauNe);*/
    }
    #endregion

    #region déplacement des êtres vivants
    //Fonction à appeler quand le joueur déplace un etre vivant dans une nouvelle salle ou île
    //S'il y a un animal de son espèce de sexe opposé dans la nouvelle salle, on change enCouple = true, sinon enCouple = false;
    public void DeplacerEtreVivant(SalleAnimaux salleinitiale, SalleAnimaux sallefinale)
    {
        bool _isMovable = true;

        foreach (EtreVivant etrevivantsalle in sallefinale.Animaux)
        {
            foreach (EnumRace etrevivantdeteste in this.AnimauxDetestes)
            {
                if (etrevivantdeteste == etrevivantsalle.Race)
                {
                    _isMovable = false;
                }
            }
        }

        if (sallefinale.TailleOcuppee + this.Taille > sallefinale.Taille)
        {
            Debug.Log("Vous ne pouvez pas déplacer cet animal ici ! La salle est trop pleine !");
        }

        else if (_isMovable == false)
        {
            Debug.Log("Vous ne pouvez pas déplacer cet animal ici ! La salle contient un animal détesté !");
        }

        else
        {
            //gestion de enCouple
            foreach(EtreVivant etrevivant in sallefinale.Animaux)
            {
                if ((etrevivant.Race == this.Race) && (etrevivant.Sexe != this.Sexe)) 
                {
                    EnCouple = true;
                }
                else
                {
                    EnCouple = false;
                }
            }
            salleinitiale.TailleOcuppee -= this.Taille;
            sallefinale.TailleOcuppee += this.Taille;
            salleinitiale.Animaux.Remove(this);
            sallefinale.Animaux.Add(this);
            Debug.Log("Déplacement effectué !");
        }
    }

    public void DeplacerEtreVivant(SalleAnimaux salleinitiale, Destination destinationfinale)
    {
        salleinitiale.TailleOcuppee -= this.Taille;
        salleinitiale.Animaux.Remove(this);
        destinationfinale.etreVivant.Add(this);
    }

    //quand on déplace un animal vers le navire, il apparaît toujours dans la même salle dédiée (salle d'embarquement)
    public void DeplacerEtreVivant(Destination destinationinitiale) 
    {
        SalleEmbarquement salleEmbarquement = FindObjectOfType<SalleEmbarquement>();
        salleEmbarquement.Animaux.Add(this);
        destinationinitiale.etreVivant.Remove(this);
    }

    //quand on déplace un animal vers la cuisine
    public void DeplacerEtreVivant(SalleAnimaux salleinitiale, SalleCuisine sallecuisine)
    {
        salleinitiale.TailleOcuppee -= this.Taille;
        salleinitiale.Animaux.Remove(this);
        Mort();
        this.vaisseau.AjouterNourritureViande(this.QuantiteeDeViandeProduite);
    }
    #endregion

    #region gestion du temps
    //Fonction à appeler sur tous les EtreVivant à chaque fois que le joueur effectue une action qui prend un certain nombre de jours.
    public void TempsQuiPasse(int NombreDeJoursQuiPassent) 
    {
        this.JoursVecus += NombreDeJoursQuiPassent;

        if (this.JoursVecus >= this.PeriodeDeVie)
        {
            Mort();
        }

        if (this.EnCouple)
        {
            PeriodeDepuisEnCouple += NombreDeJoursQuiPassent;
        }

        if (this.PeriodeDepuisEnCouple >= this.PeriodeDeReproduction)
        {
            Reproduction();
            PeriodeDepuisEnCouple = 0;
        }

        if (this.NourritureFavorite == NourritureType.NOURRITUREVIANDE)
        {
            this.vaisseau.ConsommerNourritureViande(this.NourritureConsommee);
        }

        if (this.NourritureFavorite == NourritureType.NOURRITUREVEG)
        {
            this.vaisseau.ConsommerNourritureVeg(this.NourritureConsommee);
        }
    }
    #endregion

    #endregion
}

