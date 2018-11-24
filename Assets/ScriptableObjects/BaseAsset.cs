using UnityEngine;
using System;

public class BaseAsset : ScriptableObject
{
    public int level;
    public string cardName;
    public Sprite image;
    
    public string description;

    public int[] properties;

    public BaseAsset()
    {
        properties = new int[Enum.GetValues(typeof(ElementsTypes.ElementType)).Length];
    }
}