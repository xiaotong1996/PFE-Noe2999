using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawIsland : MonoBehaviour
{
    [SerializeField]
    private int ileNumber;

    public GameObject Earth;
    public GameObject Spawned;

    public int IleNumber { get => ileNumber; set => ileNumber = value; }

    private GameObject vaisseau;
    private List<GameObject> islands;

    private int spawnedCount;

    private float displaytime = 4.0f;

    void Start()
    {
        islands = new List<GameObject>();
        vaisseau = GameObject.FindGameObjectWithTag("Vaisseau");

        spawnIsland(IleNumber);
        spawnedCount = 0;

    }

    private void Update()
    {
        if (GameManager.Instance.SeaLevel < 1800 && spawnedCount == 0)
        {
            spawnIsland(1);
            spawnedCount++;
            MyNotifications.CallNotification("", displaytime);
        }
        if (GameManager.Instance.SeaLevel < 1500 && spawnedCount == 1)
        {
            spawnIsland(1);
            spawnedCount++;
            MyNotifications.CallNotification("", displaytime);
        }
        if (GameManager.Instance.SeaLevel < 1000 && spawnedCount == 2)
        {
            spawnIsland(2);
            spawnedCount++;
            MyNotifications.CallNotification("", displaytime);
        }
        if (GameManager.Instance.SeaLevel < 500 && spawnedCount == 3)
        {
            spawnIsland(2);
            spawnedCount++;
            MyNotifications.CallNotification("", displaytime);
        }

    }

    public void spawnIsland(int ileNumber)
    {
        for (int i = 0; i < ileNumber; i++)
        {
            var r = Earth.GetComponent<SphereCollider>().radius;

            var origin = Earth.gameObject.transform.position;
            var onEarth = Random.onUnitSphere * r * 100;

            var spawnedIle = Instantiate(Spawned, onEarth, Quaternion.identity, Earth.transform) as GameObject;
            spawnedIle.transform.LookAt(Earth.transform.position);
            spawnedIle.transform.rotation = spawnedIle.transform.rotation * Quaternion.Euler(90, 0, 0);

            if (detectOverlap(spawnedIle.GetComponent<Collider>()))
            {
                //Debug.Log("overlap");
                Destroy(spawnedIle);
                i--;
            }
            else
            {
                islands.Add(spawnedIle);
            }
            //var x = Random.Range(-1f, 1f);
            //var y = Random.Range(-1f, 1f);
            //var z = Random.Range(-1f, 1f);

            //var vec = new Vector3(x, y, z).normalized * r*100;
          
           
        }
    }

    private bool detectOverlap(Collider islandCollider)
    {
        var vaisseauCollider = vaisseau.GetComponent<Collider>();
        foreach(var island in islands)
        {
            if (island.GetComponent<Collider>().bounds.Intersects(islandCollider.bounds))
            {
                Debug.Log(island.name);
                return true;
            }
        }

        return islandCollider.bounds.Intersects(vaisseauCollider.bounds);  
    }

}
