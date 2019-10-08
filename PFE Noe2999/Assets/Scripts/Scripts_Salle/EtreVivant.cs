using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtreVivant : MonoBehaviour
{
    public string description; //la description de l'être vivant à afficher lorsque le joueur passe sa sourie dessus par exemple ; il faut aussi afficher les autres informations comme la duréedevie, nourriture, etc.

    [SerializeField]
    private int taille;
    public int Taille { get => taille; set => taille = value; }

    [SerializeField]
    private NourritureType nourritureFavorite;
    public NourritureType NourritureFavorite { get => nourritureFavorite; set => nourritureFavorite = value; }

    [SerializeField]
    private int nourritureConsommee;
    public int NourritureConsommee { get => nourritureConsommee; set => nourritureConsommee = value; }

    [SerializeField]
    private int periodeDeVie;
    public int PeriodeDeVie { get => periodeDeVie; set => periodeDeVie = value; }

    [SerializeField]
    private int joursVecus;
    public int JoursVecus { get => joursVecus; set => joursVecus = value; }

    [SerializeField]
    private int periodeDeReproduction;
    public int PeriodeDeReproduction { get => periodeDeReproduction; set => periodeDeReproduction = value; }

    [SerializeField]
    private int periodeDepuisEnCouple;
    public int PeriodeDepuisEnCouple { get => periodeDepuisEnCouple; set => periodeDepuisEnCouple = value; }

    [SerializeField]
    private EcosystemeType ecosystemeFavorit;
    public EcosystemeType EcosystemeFavorit { get => ecosystemeFavorit; set => ecosystemeFavorit = value; }

    //Pour le moment j'ai mélangé animaux et êtres vivants, on peut imaginer plus tard de séparer les champs qui suivent pour les mettre dans animaux seulement

    [SerializeField]
    private int quantiteeDeViandeProduite; //pour quand on implémentera la cuisine
    public int QuantiteeDeViandeProduite { get => quantiteeDeViandeProduite; set => quantiteeDeViandeProduite = value; }

    [SerializeField]
    private EnumRace race;
    public EnumRace Race { get => race; set => race = value; }


    [SerializeField] //Ce qui pourrait être chouette, c'est de n'avoir ce type de mécanique que pour quelques animaux (ex : chiens et chats qui se détestent et ne peuvent pas être dans la même salle
                     //et d'avoir d'autres mécaniques pour les autres.
    private List<EnumRace> animauxDetestes;
    public List<EnumRace> AnimauxDetestes { get => animauxDetestes; set => animauxDetestes = value; }

    [SerializeField]
    private EnumSexe sexe;
    public EnumSexe Sexe { get => sexe; set => sexe = value; }

    [SerializeField]
    private bool enCouple;
    public bool EnCouple { get => enCouple; set => enCouple = value; }

public void Mort()
    {
        Destroy(gameObject);
    }

    public void Reproduction()
    {

    }

public void DeplacerEtreVivant(Salle _salle) //Fonction à appeler quand le joueur déplace un etre vivant dans une nouvelle salle, ou quand un animal apparaît dans une nouvelle salle elle prend en paramètre cette nouvelle salle
                                            //S'il y a un animal de son espèce de sexe opposé dans la nouvelle salle, on change enCouple = true, sinon enCouple = false;
    {

    }

    public void TempsQuiPasse(int NombreDeJoursQuiPassent, Vaisseau _vaisseau) //Fonction à appeler sur tous les EtreVivant à chaque fois que le joueur effectue une action qui prend un certain nombre de jours.
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
        }
        {
            Mort();
        }
        if (this.NourritureFavorite == NourritureType.NOURRITUREVIANDE)
        {
            _vaisseau.NourritureViande -= this.NourritureConsommee;
        }
        if (this.NourritureFavorite == NourritureType.NOURRITUREVEG)
        {
           _vaisseau.NourritureVeg -= this.NourritureConsommee;
        }
    }
}

