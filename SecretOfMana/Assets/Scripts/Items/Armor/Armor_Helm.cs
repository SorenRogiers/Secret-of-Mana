using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_Helm : Armor
{
    public Armor_Helm(string name, int defense)
    {
        Name = name;
        ArmorType = ArmorTypes.Helm;
        Defense = defense;
    }
}
