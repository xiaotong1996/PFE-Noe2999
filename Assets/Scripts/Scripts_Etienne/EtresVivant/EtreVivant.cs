using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtreVivant : MonoBehaviour
{
    #region Déclaration des variables

    //la description de l'être vivant à afficher lorsque le joueur passe sa sourie dessus par exemple ; il faut aussi afficher les autres informations comme la duréedevie, nourriture, etc.
    public string description; 

    protected Vaisseau vaisseau;

    [SerializeField]
    private SalleAnimaux positionSalle;
    public SalleAnimaux PositionSalle { get => positionSalle; set => positionSalle = value; }

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

    #region variables liées au couple

    [SerializeField]
    private int joursVAvantMaturite;
    public int JoursAvantMaturite { get => joursVAvantMaturite; protected set => joursVAvantMaturite = value; }

    [SerializeField]
    private bool estMature;
    public bool EstMature { get => estMature; set => estMature = value; }

    [SerializeField]
    private int periodeDeReproduction;
    public int PeriodeDeReproduction { get => periodeDeReproduction; protected set => periodeDeReproduction = value; }

    [SerializeField]
    private int periodeDepuisEnCouple;
    public int PeriodeDepuisEnCouple { get => periodeDepuisEnCouple; protected set => periodeDepuisEnCouple = value; }

    [SerializeField]
    private EnumSexe sexe;
    public EnumSexe Sexe { get => sexe; protected set => sexe = value; }

    [SerializeField]
    private bool enCouple;
    public bool EnCouple { get => enCouple; protected set => enCouple = value; }

    [SerializeField]
    private EtreVivant enCoupleAvec;
    public EtreVivant EnCoupleAvec { get => enCoupleAvec; protected set => enCoupleAvec = value; }

    #endregion

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

    #endregion

    protected EtreVivant()
    {
        vaisseau = FindObjectOfType<Vaisseau>();
        JoursVecus = 0;
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
    }
    #region méthodes 

    #region méthodes privées
    //Le joueur doit pouvoir appeler cette méthode n'importe quand pour pouvoir tuer un animal
    private void Mort()
    {
        Destroy(gameObject);
        //TODO?
    }
    
    //Celle ci est un peu moche
    private void Reproduction()
    {
        if (this.Race == EnumRace.CHAT)
        {
            Chat nouveauNe = new Chat(0);
            SalleNaissance salleNaissance = FindObjectOfType<SalleNaissance>();
            nouveauNe.positionSalle = salleNaissance;
            salleNaissance.Animaux.Add(nouveauNe);
            Debug.Log("Un chat est né !");
        }
        else if (this.Race == EnumRace.CHIEN)
        {
            Chien nouveauNe = new Chien(0);
            SalleNaissance salleNaissance = FindObjectOfType<SalleNaissance>();
            nouveauNe.positionSalle = salleNaissance;
            salleNaissance.Animaux.Add(nouveauNe);
            Debug.Log("Un chien est né !");
        }
        else if (this.Race == EnumRace.POULE)
        {
            Poule nouveauNe = new Poule(0);
            SalleNaissance salleNaissance = FindObjectOfType<SalleNaissance>();
            nouveauNe.positionSalle = salleNaissance;
            salleNaissance.Animaux.Add(nouveauNe);
            Debug.Log("Une poule est né !");
        }
        else if (this.Race == EnumRace.ZEBRE)
        {
            Zebre nouveauNe = new Zebre(0);
            SalleNaissance salleNaissance = FindObjectOfType<SalleNaissance>();
            nouveauNe.positionSalle = salleNaissance;
            salleNaissance.Animaux.Add(nouveauNe);
            Debug.Log("Un zebre est né !");
        }
        else if (this.Race == EnumRace.LION)
        {
            Lion nouveauNe = new Lion(0);
            SalleNaissance salleNaissance = FindObjectOfType<SalleNaissance>();
            nouveauNe.positionSalle = salleNaissance;
            salleNaissance.Animaux.Add(nouveauNe);
            Debug.Log("Un lion est né !");
        }

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
                if ((etrevivant.Race == this.Race) && (etrevivant.Sexe != this.Sexe)&&(etrevivant.EstMature)&&(etrevivant.EnCouple == false))
                {
                    etrevivant.EnCouple = true;
                    etrevivant.EnCoupleAvec = this;
                    this.EnCoupleAvec = etrevivant;
                    this.EnCouple = true;
                    this.PeriodeDepuisEnCouple = 0;
                    break;
                }
                else
                {
                    this.EnCouple = false;
                    this.EnCoupleAvec = null;
                    this.PeriodeDepuisEnCouple = 0;
                }
            }
            salleinitiale.TailleOcuppee -= this.Taille;
            sallefinale.TailleOcuppee += this.Taille;
            salleinitiale.Animaux.Remove(this);
            sallefinale.Animaux.Add(this);
            this.PositionSalle = sallefinale;
            Debug.Log("Déplacement effectué !");
        }
    }

    public void DeplacerEtreVivant(SalleAnimaux salleinitiale, Destination destinationfinale)
    {
        salleinitiale.TailleOcuppee -= this.Taille;
        salleinitiale.Animaux.Remove(this);
        destinationfinale.etreVivant.Add(this);
        this.PositionSalle = null;
    }

    //quand on déplace un animal vers le navire, il apparaît toujours dans la même salle dédiée (salle d'embarquement)
    public void DeplacerEtreVivant(Destination destinationinitiale) 
    {
        SalleEmbarquement salleEmbarquement = FindObjectOfType<SalleEmbarquement>();
        salleEmbarquement.Animaux.Add(this);
        destinationinitiale.etreVivant.Remove(this);
        this.PositionSalle = salleEmbarquement;
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
            if (this.EnCoupleAvec != null)
            {
                this.EnCoupleAvec.EnCoupleAvec = null;
                this.EnCoupleAvec.PeriodeDepuisEnCouple = 0;
                this.EnCoupleAvec.EnCouple = false;
            }
            Mort();
        }

        #region gestion du couple

        if ((this.JoursVecus >= this.JoursAvantMaturite)&&(this.EstMature ==false))
        {
            this.EstMature = true;
        }

        if ((this.EstMature == true)&&(this.EnCouple == false))
        {
            foreach (EtreVivant partenairePotentiel in this.PositionSalle.Animaux)
            {
                if ((partenairePotentiel.Sexe != this.Sexe)&&(partenairePotentiel.EstMature)&&(partenairePotentiel.EnCouple == false)&&(partenairePotentiel.Race == this.Race))
                {
                    this.EnCouple = true;
                    partenairePotentiel.EnCouple = true;
                    this.EnCoupleAvec = partenairePotentiel;
                    partenairePotentiel.EnCoupleAvec = this;
                    break;
                }
            }
        }

        if ((this.EnCouple)&&(this.EstMature)) 
        {
            PeriodeDepuisEnCouple += NombreDeJoursQuiPassent;
        }

        if ((this.PeriodeDepuisEnCouple >= this.PeriodeDeReproduction)&&(this.Sexe == EnumSexe.FEMELLE))
        {
            Reproduction();
            PeriodeDepuisEnCouple = 0;
        }

        #endregion

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

