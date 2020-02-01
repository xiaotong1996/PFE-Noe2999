using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EtreVivant : MonoBehaviour
{
    #region Déclaration des variables

    //la description de l'être vivant 
    public string description; 

   

    public SpriteRenderer spriteRenderer;
    public Sprite HumeurHeureux;
    public Sprite HumeurTriste;
    public Sprite HumeurAffame;
    public Sprite HumeurFatigue;
    public Sprite HumeurRepus;
    public Sprite HumeurAmoureux;
    public Sprite HumeurDodo;

    [SerializeField]
    private SalleAnimaux positionSalle;
    public SalleAnimaux PositionSalle { get => positionSalle; set => positionSalle = value; }

    [SerializeField]
    private string id;
    public string Id { get => id; set => id = value; }

    [SerializeField]
    private Destination positionDestination;
    public Destination PositionDestination { get => positionDestination; set => positionDestination = value; }

    [SerializeField]
    private NourritureType nourritureFavorite;
    public NourritureType NourritureFavorite { get => nourritureFavorite;  set => nourritureFavorite = value; }

    [SerializeField]
    private List<NourritureType> nourritureMangeable;
    public List<NourritureType> NourritureMangeable { get => nourritureMangeable;  set => nourritureMangeable = value; }

    #region Variables liées au temps qui passe

    [SerializeField]
    private float estomac;
    public float Estomac { get => estomac;  set => estomac = value; }

    [SerializeField]
    private float fatigue;
    public float Fatigue { get => fatigue;  set => fatigue = value; }

    [SerializeField]
    private float chronolimite;
    public float Chronolimite { get => chronolimite;  set => chronolimite = value; }

    [SerializeField]
    private float chronometre;
    public float Chronometre { get => chronometre;  set => chronometre = value; }

    [SerializeField]
    private float chronoSprite;
    public float ChronoSprite { get => chronoSprite;  set => chronoSprite = value; }

    [SerializeField]
    private bool estEnTrainDeDormir;
    public bool EstEnTrainDeDormir { get => estEnTrainDeDormir;  set => estEnTrainDeDormir = value; }

    #endregion

    #region variables liées au couple

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

    [SerializeField]
    private EnumRace race;
    public EnumRace Race { get => race; protected set => race = value; }

    //Ce qui pourrait être chouette, c'est de n'avoir ce type de mécanique que pour quelques animaux (ex : chiens et chats qui se détestent et ne peuvent pas être dans la même salle
    //et d'avoir d'autres mécaniques pour les autres.
    [SerializeField] 
    private List<EnumRace> animauxDetestes;
    public List<EnumRace> AnimauxDetestes { get => animauxDetestes; protected set => animauxDetestes = value; }

    #endregion


    public bool CanEat(NourritureType n)
    {
        if (n == NourritureFavorite)
            return true;
        foreach(var i in NourritureMangeable)
        {
            if (i == n)
                return true;
        }
        return false;
    }

    public bool CanInThisRoom(SalleAnimaux s)
    {
       //Debug.Log("test " + s.name);
        foreach(var i in s.Animaux)
        {
          
            if (AnimauxDetestes.Contains(i.Race))
                return false;
            if (i.AnimauxDetestes.Contains(Race))
                return false;
        }

        return true;
    }

    public bool CanOnThisIland(Destination island)
    {
        if(island.Ecosysteme.EcosystemeType == ecosystemeFavorit)
            return true;

        return false;
    }

    public void EtreVivantCopy(EtreVivant a)
    {
       description = a.description;
       //spriteRenderer = a.spriteRenderer;
       HumeurHeureux = a.HumeurHeureux;

        HumeurTriste = a.HumeurTriste;

        HumeurAffame = a.HumeurAffame;

        HumeurFatigue = a.HumeurFatigue;

        HumeurRepus = a.HumeurRepus;

        HumeurAmoureux = a.HumeurAmoureux;
        HumeurDodo = a.HumeurDodo;

        PositionSalle = a.PositionSalle;

        Id = a.Id;

    

    PositionDestination = a.PositionDestination;
    
    nourritureFavorite = a.nourritureFavorite;
    
    nourritureMangeable = a.nourritureMangeable;
    #region Variables liées au temps qui passe

    
    estomac = a.estomac;
    
    fatigue = a.fatigue;
   
    chronolimite = a.chronolimite;
    
    chronometre = a.chronometre;
    
    chronoSprite = a.chronoSprite;
   
    estEnTrainDeDormir = a.estEnTrainDeDormir;
    #endregion

    #region variables liées au couple

    
    
    enCouple = a.enCouple;
    
    enCoupleAvec = a.enCoupleAvec;
    #endregion

    
    ecosystemeFavorit = a.ecosystemeFavorit;

    
    EstDansUnEcosystemeViable = a.EstDansUnEcosystemeViable;
    
    Race = a.Race;
    
    animauxDetestes = a.animauxDetestes;
}
protected EtreVivant() { 
    

    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        
       
    }
    void Update()
    {
        //Debug.Log("qqqqq" + gameObject.name + " " + Id);
        if (spriteRenderer.enabled == true)
        {
            ChronoSprite += Time.deltaTime;
            if (ChronoSprite >= 2f)
            {
                spriteRenderer.enabled = false;
                ChronoSprite = 0f;
            }
        }
        TempsQuiPasse();
        AnimalDataModel.UpdateAnimalInfo(this);
        //Debug.Log("a " + fatigue);
        //Debug.Log("aa " + fatigue);

    }

    #region méthodes 

    #region méthodes privées
    //Le joueur doit pouvoir appeler cette méthode n'importe quand pour pouvoir tuer un animal
    private void Mort()
    {
        Destroy(gameObject);
        //TODO?
    }
    #endregion

    #region déplacement des êtres vivants
    //Fonction à appeler quand le joueur déplace un etre vivant dans une nouvelle salle ou île
    //S'il y a un animal de son espèce dans la nouvelle salle, on change enCouple = true, sinon enCouple = false;
    public bool DeplacerEtreVivant(SalleAnimaux salleinitiale, SalleAnimaux sallefinale)
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

        if (sallefinale.TailleOcuppee + 1 > sallefinale.Taille)
        {
            Debug.Log("Vous ne pouvez pas déplacer cet animal ici ! La salle est trop pleine !");
            return false;
        }

        else if (_isMovable == false)
        {
            Debug.Log("Vous ne pouvez pas déplacer cet animal ici ! La salle contient un animal détesté !");
            return false;
        }

        else
        {
            //gestion de enCouple
            foreach(EtreVivant etrevivant in sallefinale.Animaux)
            {
                if ((etrevivant.Race == this.Race) && (etrevivant.EnCouple == false))
                {
                    etrevivant.EnCouple = true;
                    etrevivant.EnCoupleAvec = this;
                    this.EnCoupleAvec = etrevivant;
                    this.EnCouple = true;
                    break;
                }
                else
                {
                    this.EnCouple = false;
                    this.EnCoupleAvec = null;
                }
            }
            //if(sallefinale.TailleOcuppee == 0)
            //{
            //    sallefinale.SalleType = this.tag == "Herbivore" ? EnumSalleType.SALLEHERBIVORE : EnumSalleType.SALLECARNIVORE;
            //}
            int idx = 0;
            foreach(var pair in Vaisseau.Instance.Salles)
            {
                if (pair.Value == sallefinale)
                    idx = pair.Key;

            }
            AnimalDataModel.SetSalleIdx(this, idx);

            salleinitiale.TailleOcuppee -= 1;
            sallefinale.TailleOcuppee += 1;
            salleinitiale.Animaux.Remove(this);
            sallefinale.Animaux.Add(this);
            if (salleinitiale.TailleOcuppee == 0)
                salleinitiale.SalleType = EnumSalleType.NONE;
            this.PositionSalle = sallefinale;
            //Debug.Log(sallefinale.SalleType);
            Debug.Log("Déplacement effectué !");
            return true;
        }

       
    }

    public bool DeplacerEtreVivant(SalleAnimaux salleinitiale, Destination destinationfinale)
    {

        AnimalDataModel.RemoveAnimal(this);
        salleinitiale.TailleOcuppee -= 1;
        if (salleinitiale.TailleOcuppee == 0)
            salleinitiale.SalleType = EnumSalleType.NONE;
        salleinitiale.Animaux.Remove(this);
        destinationfinale.EtreVivant.Add(Race);
        this.positionDestination = destinationfinale;
        if (destinationfinale.Ecosysteme.EcosystemeType == EcosystemeFavorit)
        {
            UIManager.Instance.SetEnergyTextValue(10);
            ShowHumeur(HumeurHeureux);
            GameManager.Instance.AjouterEnergie(10);
        }
        else
        {
            ShowHumeur(HumeurTriste);
        }
        this.PositionSalle = null;
        return true;
    }

    //quand on déplace un animal d'une île vers une salle du navire
    public bool DeplacerEtreVivant(Destination destinationinitiale, SalleAnimaux sallefinale) 
    {

        destinationinitiale.EtreVivant.Remove(Race);
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

            if (sallefinale.TailleOcuppee + 1 > sallefinale.Taille)
            {
                Debug.Log("Vous ne pouvez pas déplacer cet animal ici ! La salle est trop pleine !");
                return false;
        }

            else if (_isMovable == false)
            {
                Debug.Log("Vous ne pouvez pas déplacer cet animal ici ! La salle contient un animal détesté !");
                 return false;
        }

            else
            {
                //gestion de enCouple
                foreach (EtreVivant etrevivant in sallefinale.Animaux)
                {
                    if ((etrevivant.Race == this.Race) && (etrevivant.EnCouple == false))
                    {
                        etrevivant.EnCouple = true;
                        etrevivant.EnCoupleAvec = this;
                        this.EnCoupleAvec = etrevivant;
                        this.EnCouple = true;
                        break;
                    }
                    else
                    {
                        this.EnCouple = false;
                        this.EnCoupleAvec = null;
                    }
                }
            //if (sallefinale.TailleOcuppee == 0)
            //{
            //    sallefinale.SalleType = this.tag == "Herbivore" ? EnumSalleType.SALLEHERBIVORE : EnumSalleType.SALLECARNIVORE;
            //}
            int idx = 0;
            foreach (var pair in Vaisseau.Instance.Salles)
            {
                if (pair.Value == sallefinale)
                    idx = pair.Key;

            }
            AnimalDataModel.SetSalleIdx(this, idx);
            sallefinale.TailleOcuppee += 1;
            sallefinale.Animaux.Add(this);
            this.PositionSalle = sallefinale;
            this.positionDestination = null;
            Debug.Log("Déplacement effectué !");
            return true;
        }
        
    }

    #endregion

    #region gestion du temps et des humeurs

    private EnumHumeur QuelleHumeur()
    {
        EnumHumeur resultat = EnumHumeur.HEUREUX;
        if (Estomac <= 3)
        {
            resultat = EnumHumeur.AFFAME;
        }
        else if (EnCouple == true)
        {
            if (UnityEngine.Random.value >= 0.5)
            {
                resultat = EnumHumeur.AMOUREUX;
            }
        }
        else
        {
            if (UnityEngine.Random.value >= 0.7)
            {
                resultat = EnumHumeur.TRISTE;
            }
        }
        if (fatigue == 0f)
        {
            resultat = EnumHumeur.FATIGUE;
        }
        return resultat;
    }

    private void ShowHumeur(Sprite humeur)
    {
        spriteRenderer.sprite = humeur;
        spriteRenderer.enabled = true;
    } 

    private void DisplayHumeur()
    {
        EnumHumeur humeur = QuelleHumeur();
        if (humeur == EnumHumeur.HEUREUX)
        {
            ShowHumeur(HumeurHeureux);
        }
        if (humeur == EnumHumeur.TRISTE)
        {
            ShowHumeur(HumeurTriste);
        }
        if (humeur == EnumHumeur.AFFAME)
        {
            ShowHumeur(HumeurAffame);
        }
        if (humeur == EnumHumeur.AMOUREUX)
        {
            ShowHumeur(HumeurAmoureux);
        }
        if (humeur == EnumHumeur.FATIGUE)
        {
            ShowHumeur(HumeurFatigue);
        }
        Debug.Log("displayasdasd");
        //TODO : Charger l'énergie si c'est une bonne humeur !
        if (humeur == EnumHumeur.HEUREUX)
        {
            UIManager.Instance.SetEnergyTextValue(10);
            GameManager.Instance.AjouterEnergie(10);
        }
    }

    //Fonction à appeler sur tous les EtreVivant tout le temps
    public void TempsQuiPasse()
    {
        Chronometre += Time.deltaTime;
        if (Chronometre >= Chronolimite)
        {
            Chronometre = 0f;
            if (GameManager.Instance.IsSleep == false)
            {

                //Debug.Log("dalse");
                Estomac -= 0.5f;
                Fatigue -= (0.1f*Time.deltaTime);// + UnityEngine.Random.value / 2);
            //Debug.Log(Fatigue);
                if (Fatigue < 0)
                {
                    Fatigue = 0f;
                }
                if (Estomac < 0)
                {
                    Estomac = 0;
                }

                if (UnityEngine.Random.value >= 0.5)
                {
                    DisplayHumeur();
                }
            }
            else
            {
                Debug.Log("trueeeeeee");
                // problème : ça risque de ne pas se recharger si je quitte l'application !
                ShowHumeur(HumeurDodo);
                Fatigue += 0.3f;
                if (Fatigue > 10f)
                {
                    Fatigue = 10f;
                }
            }          
        }
    }
    #endregion

    //à appeler quand l'animal va dormir
    public void VaDormir()
    {
        EstEnTrainDeDormir = true;
    }

    //à appeler quand l'animal se réveille
    public void SeReveille()
    {
        EstEnTrainDeDormir = false;
    }

    //à appeler quand le joueur donne de la nourriture à un animal,^prend en paramètre la nourriture donnée
    public bool NourrirAnimal(NourritureType nourriture)
    {
        Debug.Log("yes3");
        if (nourriture == NourritureFavorite)
        {
            Estomac += 5f;
            if (Estomac > 10f)
            {
                Estomac = 10f;
            }
            //TODO : afficher que l'animal est très content ; recharger l'énergie 
            ShowHumeur(HumeurHeureux);
            UIManager.Instance.SetEnergyTextValue(10);
            GameManager.Instance.AjouterEnergie(10);
            Debug.Log("yes1");
            return true;

        }
        else if (NourritureMangeable.Contains(nourriture))
        {
            Estomac += 2f;
            if (Estomac > 10f)
            {
                Estomac = 10f;
            }
            //TODO : afficher que l'animal est moyen content
            ShowHumeur(HumeurAmoureux);
            UIManager.Instance.SetEnergyTextValue(5);
            GameManager.Instance.AjouterEnergie(5);
            Debug.Log("yes2");
            return true;
        }

        ShowHumeur(HumeurTriste);
        return false;
    }
    #endregion


  

}

