using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoxDataModel 
{
    private static Dictionary<string,Item> GridItem = new Dictionary<string, Item>();
    

    public static void StoreItem(string gridName, Item item)
    {
        if (GridItem.ContainsKey(gridName))
            DeleteItem(gridName);

       
        GridItem.Add(gridName,item);
    }

    public static Dictionary<string, Item>  GetGridITem()
    {
        return GridItem;
    }

    public static void AddItem(string gridName, Item item)
    {
        if (GridItem.ContainsKey(gridName))
            GridItem[gridName].Number++;
    }

    public static void ReduceItem(string gridName, Item item)
    {
        if (GridItem.ContainsKey(gridName))
        {
            if (GridItem[gridName].Number > 0)
                GridItem[gridName].Number--;
            else
                DeleteItem(gridName);
        }
    }


    public static string FindGrid(string itemName)
    {
        foreach(var pair in GridItem)
        {
            if (pair.Value.Name == itemName)
                return pair.Key;

        }

        return null;
    }

    public static Item GetItem(string gridName)
    {
        if (GridItem.ContainsKey(gridName))
            return GridItem[gridName];
        else
            return null;
    }


    public static void DeleteItem(string gridName)
    {
        if (GridItem.ContainsKey(gridName))
            GridItem.Remove(gridName);
    }
}
