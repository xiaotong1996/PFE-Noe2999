using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Icon { get; private set; }
    public int Number { get; set; }
    public NourritureType FoodType;


    public  Item(int id, string name, string description, string icon, int number, NourritureType foodType)
    {
        Id = id;
        Name = name;
        Description = description;
        Icon = icon;
        Number = number;
        FoodType = foodType;
    }

    
}
