using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LoadBackground is used to change island background image when player enter an island.
/// </summary>
public class LoadBackground : MonoBehaviour
{
    private GameObject currentDestination;

    public GameObject CurrentDestination { get => currentDestination; set => currentDestination = value; }

    //public Sprite desertBg;
    public Sprite plaineBg;
    public Sprite savaneBg;

    //private GameObject islandBg;
    public Transform centrePoint;

    // Start is called before the first frame update
    void Start()
    {
        currentDestination = GameManager.Instance.JoueurDestination;
        //islandBg = transform.GetChild(0).gameObject;
        if (currentDestination != null)
        {
            LoadBg();
            ChangeBg();
        }
    }

    void LoadBg()
    {
        //desertBg = Resources.Load<Sprite>("Images/Island/Paysage_desert");
        plaineBg = Resources.Load<Sprite>("Images/Island/Paysage_plaine");
        savaneBg = Resources.Load<Sprite>("Images/Island/Paysage_savane");
    }

    void ChangeBg()
    {
        var destion = currentDestination.GetComponent<Destination>();

        var spriteRender = GetComponent<SpriteRenderer>();

        switch (destion.Ecosysteme.EcosystemeType)
        {
            case EcosystemeType.FORET:
                spriteRender.sprite = plaineBg;
                break;
            case EcosystemeType.DESERT:
                spriteRender.sprite = plaineBg;
                break;
            case EcosystemeType.NEIGE:
                spriteRender.sprite = savaneBg;
                break;
            case EcosystemeType.PLAINE:
                spriteRender.sprite = plaineBg;
                break;
            case EcosystemeType.SAVANE:
                spriteRender.sprite = savaneBg;
                break;
            default:
                break;
        }
    }
}
