﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Food : Item
{
    public Food(int id, string name, string description, string icon, int number, NourritureType foodType) : base(id, name, description, icon, number, foodType)
    {
    }
}
