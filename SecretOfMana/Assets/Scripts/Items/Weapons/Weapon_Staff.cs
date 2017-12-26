using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Staff : Weapon {

	public Weapon_Staff(string name)
    {
        Name = name;
        WeaponType = WeaponTypes.Staff;
        AttackRange = 10;
    }

    public override GameObject UseWeapon(VisualCharacter staffOwner)
    {
        RaycastHit hit;
        Vector3 rayDirection = staffOwner.transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(staffOwner.transform.position, rayDirection * AttackRange, Color.red);

        if ((Physics.Raycast(staffOwner.transform.position, rayDirection, out hit, AttackRange) && (hit.collider.CompareTag("Player"))))
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}
