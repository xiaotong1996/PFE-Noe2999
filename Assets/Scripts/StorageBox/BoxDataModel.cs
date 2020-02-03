using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is a data class to save the item information in the store box
/// </summary>
public static class BoxDataModel 
{
    private static Dictionary<string,Item> GridItem = new Dictionary<string, Item>();
    

    /// <summary>
    /// To save the new item in the store box
    /// </summary>
    /// <param name="gridName">the name of the grid that will save the item</param>
    /// <param name="item"> the item that will be saved</param>
    public static void StoreItem(string gridName, Item item)
    {
        if (GridItem.ContainsKey(gridName))
            DeleteItem(gridName);

       
        GridItem.Add(gridName,item);
    }

    /// <summary>
    /// To get the dataModel 
    /// </summary>
    /// <returns></returns>
    public static Dictionary<string, Item>  GetGridITem()
    {
        return GridItem;
    }

    /// <summary>
    /// To add the number of the item that already in the box
    /// </summary>
    /// <param name="gridName"> the name of grid that save the item</param>
    /// <param name="item"></param>
    public static void AddItem(string gridName, Item item)
    {
       
        if (GridItem.ContainsKey(gridName))
            GridItem[gridName].Number++;
    }

    /// <summary>
    /// To Reduce the number of the item 
    /// </summary>
    /// <param name="gridName">the name of grid that save the item</param>
    /// <param name="item"></param>
    public static void ReduceItem(string gridName, Item item)
    {
        
        if (GridItem.ContainsKey(gridName))
        {
            if (GridItem[gridName].Number > 0)
                GridItem[gridName].Number--;
            else
            {

                DeleteItem(gridName);
                
               
            }
           
        }
    }

    /// <summary>
    /// Find the grid that save the item  whith the item name
    /// </summary>
    /// <param name="itemName"></param>
    /// <returns></returns>
    public static string FindGrid(string itemName)
    {
        foreach(var pair in GridItem)
        {
            if (pair.Value.Name == itemName)
                return pair.Key;

        }

        return null;
    }

    /// <summary>
    /// To get the item in the grid 
    /// </summary>
    /// <param name="gridName">the name of grid that save the item</param>
    /// <returns></returns>
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
