using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Bow : Weapon {

    public Weapon_Bow(string name, int attack)
    {
        Name = name;
        WeaponType = WeaponTypes.Bow;
        Attack = attack;
        AttackRange = 8;
    }

    public override GameObject UseWeapon(VisualCharacter bowOwner)
    {
        RaycastHit hit;
        Vector3 rayDirection = bowOwner.transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(bowOwner.transform.position, rayDirection * AttackRange, Color.red);

        if ((Physics.Raycast(bowOwner.transform.position, rayDirection, out hit, AttackRange) && (hit.collider.CompareTag("Enemy"))))
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}
