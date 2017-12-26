using UnityEngine;

public class Weapon_Sword : Weapon
{
    public Weapon_Sword(string name,int attack)
    {
        Name = name;
        WeaponType = WeaponTypes.Sword;
        Attack = attack;
        AttackRange = 2;
    }

    public override GameObject UseWeapon(VisualCharacter swordOwner)
    {
        RaycastHit hit;
        Vector3 rayDirection = swordOwner.transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(swordOwner.transform.position, rayDirection*AttackRange, Color.red);

        if ((Physics.Raycast(swordOwner.transform.position, rayDirection,out hit, AttackRange) && (hit.collider.CompareTag("Enemy"))))
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}
