using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIDataModel 
{
    private static float sealevel = 20;
    private static float energy = 20;

    public static void SetSeaLevel(float value)
    {

        //Debug.Log("data" + sealevel);
        sealevel = value;
        
    }

    public static void SetEnergy(float value)
    {
        energy = value;
    }

    public static float GetSeaLevel() { return sealevel; }

    public static float GetEnergy() { return energy; }
}
