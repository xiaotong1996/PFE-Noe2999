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

    void Start()
    {

        var r = Earth.GetComponent<SphereCollider>().radius;

        for (int i = 0; i < ileNumber; i++)
        {

            var origin = Earth.gameObject.transform.position;
            var onEarth = Random.onUnitSphere * r * 100;

            var spawnedIle = Instantiate(Spawned, onEarth, Quaternion.identity, Earth.transform) as GameObject;

            //var x = Random.Range(-1f, 1f);
            //var y = Random.Range(-1f, 1f);
            //var z = Random.Range(-1f, 1f);

            //var vec = new Vector3(x, y, z).normalized * r*100;

            spawnedIle.transform.LookAt(Earth.transform.position);
            spawnedIle.transform.rotation = spawnedIle.transform.rotation * Quaternion.Euler(90, 0, 0);

        }
    }

}
