using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

/// <summary>
/// unsed class
/// </summary>
public static class GetEnumRandom
{
    //static T GetValue()
    //{
    //    var v = Enum.GetValues(typeof(T));
    //    return (T)v.GetValue(new Random().Next(v.Length));
    //}

    static T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(new Random().Next(v.Length));
    }
}

public static class EnumExtensions
{
    public static Enum GetRandomEnumValue(this Type t)
    {
        return Enum.GetValues(t)          // get values from Type provided
            .OfType<Enum>()               // casts to Enum
            .OrderBy(e => Guid.NewGuid()) // mess with order of results
            .FirstOrDefault();            // take first item in result
    }
}
