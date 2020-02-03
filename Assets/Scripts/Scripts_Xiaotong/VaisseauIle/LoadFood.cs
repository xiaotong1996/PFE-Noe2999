using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LoadFood is used to Instantiate food in islands.
/// </summary>
public class LoadFood : MonoBehaviour
{
    private GameObject currentDestination;

    [SerializeField]
    private int boneNumMax;

    [SerializeField]
    private int fishNumMax;

    [SerializeField]
    private int grassNumMax;

    [SerializeField]
    private int meatNumMax;

    [SerializeField]
    private int seedNumMax;


    public GameObject CurrentDestination { get => currentDestination; set => currentDestination = value; }

    private GameObject foodParent;

    public GameObject bonePrefab;
    public GameObject fishPrefab;
    public GameObject grassPrefab;
    public GameObject meatPrefab;
    public GameObject seedPrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentDestination = GameManager.Instance.JoueurDestination;
        if (currentDestination != null)
        {
            foodParent = GameObject.Find("Food");
            LoadPrefab();
            InstanseFood();
        }
    }

    void LoadPrefab()
    {
        bonePrefab = Resources.Load<GameObject>("Prefabs/Foods/bone");
        fishPrefab = Resources.Load<GameObject>("Prefabs/Foods/fish");
        grassPrefab = Resources.Load<GameObject>("Prefabs/Foods/grass");
        meatPrefab = Resources.Load<GameObject>("Prefabs/Foods/meat");
        seedPrefab = Resources.Load<GameObject>("Prefabs/Foods/seed");

    }

    /// <summary>
    /// Instantiate various food in an island, the food's number is decided by EcosystemType.
    /// </summary>
    void InstanseFood()
    {
        var destion = currentDestination.GetComponent<Destination>();

        switch (destion.Ecosysteme.EcosystemeType)
        {
            case EcosystemeType.FORET:
                boneNumMax = 3;
                fishNumMax = 3;
                grassNumMax = 3;
                meatNumMax = 3;
                seedNumMax = 3;
                break;
            case EcosystemeType.DESERT:
                boneNumMax = 5;
                fishNumMax = 1;
                grassNumMax = 1;
                meatNumMax = 3;
                seedNumMax = 2;
                break;
            case EcosystemeType.NEIGE:
                boneNumMax = 1;
                fishNumMax = 4;
                grassNumMax = 1;
                meatNumMax = 3;
                seedNumMax = 1;
                break;
            case EcosystemeType.PLAINE:
                boneNumMax = 3;
                fishNumMax = 3;
                grassNumMax = 4;
                meatNumMax = 3;
                seedNumMax = 3;
                break;
            case EcosystemeType.SAVANE:
                boneNumMax = 3;
                fishNumMax = 2;
                grassNumMax = 3;
                meatNumMax = 3;
                seedNumMax = 3;
                break;
            default:
                break;
        }

        InstanseBone(boneNumMax);
        InstanseFish(fishNumMax);
        InstanseGrass(grassNumMax);
        InstanseMeat(meatNumMax);
        InstanseSeed(seedNumMax);

    }

    void InstanseBone(int boneNumMax)
    {
        var boneNum = Random.Range(0, boneNumMax);
        for (int i = 0; i < boneNum; ++i)
        {
            var position = new Vector3(Random.Range(-8.0f, -3.0f), Random.Range(-4.0f, 4.3f), -0.5f);
            var foodGameObject = Instantiate(bonePrefab, position, Quaternion.identity, foodParent.transform);
        }
    }

    void InstanseFish(int fishNumMax)
    {
        var fishNum = Random.Range(0, fishNumMax);
        for (int i = 0; i < fishNum; ++i)
        {
            var position = new Vector3(Random.Range(-8.0f, -3.0f), Random.Range(-4.0f, 4.3f), -0.5f);
            var foodGameObject = Instantiate(fishPrefab, position, Quaternion.identity, foodParent.transform);
        }
    }

    void InstanseGrass(int grassNumMax)
    {
        var grassNum = Random.Range(0, grassNumMax);
        for (int i = 0; i < grassNum; ++i)
        {
            var position = new Vector3(Random.Range(-8.0f, -3.0f), Random.Range(-4.0f, 4.3f), -0.5f);
            var foodGameObject = Instantiate(grassPrefab, position, Quaternion.identity, foodParent.transform);
        }
    }

    void InstanseMeat(int meatNumMax)
    {
        var meatNum = Random.Range(0, meatNumMax);
        for (int i = 0; i < meatNum; ++i)
        {
            var position = new Vector3(Random.Range(-8.0f, -3.0f), Random.Range(-4.0f, 4.3f), -0.5f);
            var foodGameObject = Instantiate(meatPrefab, position, Quaternion.identity, foodParent.transform);
        }
    }

    void InstanseSeed(int seedNumMax)
    {
        var seedNum = Random.Range(0, seedNumMax);
        for (int i = 0; i < seedNum; ++i)
        {
            var position = new Vector3(Random.Range(-8.0f, -3.0f), Random.Range(-4.0f, 4.3f), -0.5f);
            var foodGameObject = Instantiate(seedPrefab, position, Quaternion.identity, foodParent.transform);
        }
    }
}
