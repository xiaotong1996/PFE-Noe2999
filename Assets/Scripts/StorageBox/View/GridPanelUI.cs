using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPanelUI : MonoBehaviour
{
    //store all the transforms of all the grids
    [SerializeField]
    private Transform[] grids;
    public Transform[] Grids { get => grids; set => Grids = value; }


    public Transform GetFirstEmptyGrid()
    {
        for(int i = 0; i < Grids.Length; ++i)
        {
            if (Grids[i].childCount == 0)
                return Grids[i];
        }

        return null;
    }

    public Transform GetGridByName(string name)
    {
        for (int i = 0; i < Grids.Length; ++i)
        {
            if (Grids[i].name == name)
                return Grids[i];
        }

        return null;
    }

}
