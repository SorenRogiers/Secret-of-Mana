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
        ENEMY,
        NONE
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
    public Armor_Helm Helm { get; protected set; }
    public Armor_Chest Chest { get; protected set; }
    public Armor_Bracers Bracers { get; protected set; }
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
        if(item.ItemType == Item.ItemTypes.Weapon)
        {
            UnEquipItem(Weapon);

            Weapon = (item as Weapon);
            Weapon.Equipped = true;
            Weapon.EquippedBy = CharacterType;
        }
        else if(item.ItemType == Item.ItemTypes.Armor)
        {
            switch((item as Armor).ArmorType)
            {
                case Armor.ArmorTypes.Helm:
                    {
                        UnEquipItem(Helm);
                        Helm = (item as Armor_Helm);
                        Helm.Equipped = true;
                        Helm.EquippedBy = CharacterType;
                        break;
                    }
                case Armor.ArmorTypes.Chest:
                    {
                        UnEquipItem(Chest);
                        Chest = (item as Armor_Chest);
                        Chest.Equipped = true;
                        Chest.EquippedBy = CharacterType;
                        break;
                    }
                case Armor.ArmorTypes.Bracers:
                    {
                        UnEquipItem(Bracers);
                        Bracers = (item as Armor_Bracers);
                        Bracers.Equipped = true;
                        Bracers.EquippedBy = CharacterType;
                        break;
                    }
            }
        }
    }

    public void UnEquipItem(Item item)
    {
        if (item == null)
            return;

        if(item.Equipped)
        {
            item.Equipped = false;
            item.EquippedBy = Characters.NONE;

            if (item == Weapon) Weapon = null;
            else if (item == Helm) Helm = null;
            else if (item == Chest) Chest = null;
            else if (item == Bracers) Bracers = null;
        }
    }

    public int GetTotatAttackDamage()
    {
        if (Weapon != null)
            return Attack + Weapon.Attack;

        return Attack;
    }

    public int GetTotalDefense()
    {
        int helmDefense = 0;
        int chestDefense = 0;
        int bracerDefense = 0;

        if (Helm != null)
            helmDefense = Helm.Defense;

        if (Chest != null)
            chestDefense = Chest.Defense;

        if (Bracers != null)
            bracerDefense = Bracers.Defense;

        return Defense + helmDefense + chestDefense + bracerDefense;
    }
}
