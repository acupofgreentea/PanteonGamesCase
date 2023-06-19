using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static T GetRandomItem<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}