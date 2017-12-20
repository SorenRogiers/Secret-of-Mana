using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CHARACTER CLASS
 * ***************
 * Contains all the information related to characters
 * Name, HP , MP, Weapon, Stats, Level, Att, Def , type
 */
public abstract class Character
{
    public enum Characters
    {
        HERO = 0,
        GIRL,
        SPRITE,
        ENEMY
    }

    //MEMBERS
    //*******
    public string Name { get; protected set; }

    public int Health { get; protected set; }
    public int MaxHealth { get; protected set; }
    public int Mana { get; protected set; }
    public int Attack { get; protected set; }
    public int Defense { get; protected set; }

    public bool IsDead { get; protected set; }

    public Characters CharacterType { get; protected set; }

    protected VisualCharacter _visualCharacter;

    //METHODS
    //*******
    public Character()
    {
        Defense = 1;
        Attack = 1;
        MaxHealth = 100;
        Health = MaxHealth;
    }

    protected virtual void Die()
    {
        IsDead = true;
    }

    public void TakeDamage(int damageNumber)
    {
        Health -= damageNumber;

        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }

    public VisualCharacter VisualCharacter
    {
        get { return _visualCharacter; }
    }

    public void Heal (int healNumber)
    {
        Health += healNumber;

        if (Health > MaxHealth)
            Health = MaxHealth;
    }
}
