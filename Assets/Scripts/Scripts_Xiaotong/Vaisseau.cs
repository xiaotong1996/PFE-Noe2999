﻿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// C'est une classe qui contient des fonctions pour le gameobject vaiseau
/// </summary>
public class Vaisseau : MonoBehaviour
{
    private static Vaisseau instance;
    public static Vaisseau Instance { get { return instance; } }

    [SerializeField]
    private Dictionary<int, SalleAnimaux> salles = new Dictionary<int, SalleAnimaux>();
    public Dictionary<int, SalleAnimaux> Salles { get => salles; set => Salles = value; }

    public SalleAnimaux[] s;


    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        //Debug.Log(s.Length);
        int i = 0;

        foreach (SalleAnimaux v in s)
        {
            //Debug.Log("vaisseua " + v.name + " " + i);
            salles.Add(i++, v);

        }


    }
    // Start is called before the first frame update
    void Start()
    {

        Init();
        foreach (var pair in Salles)
        {
            Transform salleTransform = pair.Value.transform;

            SalleAnimaux s = pair.Value;


            for (int i = 0; i < s.Animaux.Count; i++)
            {

                float x = Random.Range(-0.5f, 0.5f) + salleTransform.position.x;

                float y = Random.Range(-0.5f, 0.5f) + salleTransform.position.y;
                Vector3 pos = new Vector3(x, y, -0.5f);
                GameObject prefab = (GameObject)Resources.Load("Prefabs/Animals/cat");
                if (s.Animaux[i].Race == EnumRace.CHAT)
                    prefab = (GameObject)Resources.Load("Prefabs/Animals/cat");
                else if (s.Animaux[i].Race == EnumRace.CHIEN)
                    prefab = (GameObject)Resources.Load("Prefabs/Animals/dog");
                else if (s.Animaux[i].Race == EnumRace.LION)
                    prefab = (GameObject)Resources.Load("Prefabs/Animals/lion");
                else if (s.Animaux[i].Race == EnumRace.POULE)
                    prefab = (GameObject)Resources.Load("Prefabs/Animals/hen");
                else if (s.Animaux[i].Race == EnumRace.ZEBRE)
                    prefab = (GameObject)Resources.Load("Prefabs/Animals/zebra");

                GameObject tmp = Instantiate(prefab, pos, Quaternion.identity);
                EtreVivant e = tmp.GetComponent<EtreVivant>();

                tmp.transform.SetParent(s.transform);
                e.EtreVivantCopy(s.Animaux[i]);
                e.PositionSalle = s;
                e.Id = s.Animaux[i].Id;
                s.Animaux[i] = e;

            }


        }
    }






    /// <summary>
    /// Initialisation pour les datas des animaux dans le vaiseau
    /// </summary>
    private void Init()
    {
        Debug.Log("value");
        Dictionary<EtreVivant, int> datamodel = AnimalDataModel.GetDataModel();
        //Salles.Clear();
        foreach (var pair in datamodel)
        {
            Salles[pair.Value].Animaux.Add(pair.Key);
            Debug.Log("value" + " " + pair.Key.Fatigue);

        }

    }



}
