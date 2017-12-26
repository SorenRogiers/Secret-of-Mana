using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    public enum ArmorTypes
    {
        Helm,
        Chest,
        Bracers
    }

    public ArmorTypes ArmorType { get; protected set; }
    
    public Armor()
    {
        ItemType = ItemTypes.Armor;
    }
}
