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
    public bool IsActive { get;set; }
    public Weapon Weapon { get; protected set; }
    public Characters CharacterType { get; protected set; }

    protected VisualCharacter _visualCharacter;

    private string _prefabPath;

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
        set { _visualCharacter = value; }
    }

    public void Heal(int healNumber)
    {
        Health += healNumber;

        if (Health > MaxHealth)
            Health = MaxHealth;
    }

    protected void DetermineCharacterModel(Characters characterType)
    {
        //Load the correct prefab depending on the characterType
        switch (CharacterType)
        {
            case Characters.HERO:
                Name = "Hero";
                _prefabPath = "Prefabs/Hero";
                break;
            case Characters.GIRL:
                Name = "Girl";
                _prefabPath = "Prefabs/Girl";
                break;
            case Characters.SPRITE:
                Name = "Sprite";
                _prefabPath = "Prefabs/Sprite";
                break;
            case Characters.ENEMY:
                Name = "Enemy";
                _prefabPath = "Prefabs/Enemy";
                break;
            default:
                goto case Character.Characters.HERO;
        }

        InstantiateCharacter();
    }

    private void InstantiateCharacter()
    {
        var characterPrefab = Resources.Load<VisualCharacter>(_prefabPath);
        VisualCharacter = Object.Instantiate(characterPrefab);
        VisualCharacter.gameObject.name = Name;
    }

    public void EquipItem(Item item)
    {
        UnEquipItem(Weapon);

        Weapon = (item as Weapon_Sword);
        Weapon.Equipped = true;
    }

    public void UnEquipItem(Item item)
    {
        if (item == null)
            return;

        if(item.Equipped)
        {
            item.Equipped = false;
            Weapon = null;
        }
    }

    public int GetTotatAttackDamage()
    {
        if (Weapon != null)
            return Attack + Weapon.Attack;

        return Attack;
    }
}
