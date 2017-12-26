using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_Chest : Armor
{
    public Armor_Chest(string name, int defense)
    {
        Name = name;
        ArmorType = ArmorTypes.Chest;
        Defense = defense;
    }
}
