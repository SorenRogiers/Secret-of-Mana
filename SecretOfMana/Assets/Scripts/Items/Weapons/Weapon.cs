using UnityEngine;

public abstract class Weapon : Item
{
    public enum WeaponTypes
    {
        Sword,
        Bow,
        Staff
    }

    public WeaponTypes WeaponType { get; protected set; }
    public float AttackRange {get; protected set;}

    public Weapon()
    {
        ItemType = ItemTypes.Weapon;
    }

    public abstract GameObject UseWeapon(VisualCharacter owner);
}
