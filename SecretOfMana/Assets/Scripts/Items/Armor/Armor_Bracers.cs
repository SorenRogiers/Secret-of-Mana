using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_Bracers : Armor
{
    public Armor_Bracers(string name, int defense)
    {
        Name = name;
        ArmorType = ArmorTypes.Bracers;
        Defense = defense;
    }
}
