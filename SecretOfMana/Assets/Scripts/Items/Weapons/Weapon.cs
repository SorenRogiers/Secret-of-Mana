public abstract class Weapon : Item
{
    public enum WeaponType
    {
        Sword,
        Bow,
        Staff
    }
	
    public WeaponType CurrentWeaponType { get; protected set; }

    public Weapon()
    {
        SetItemType(ItemType.Weapon);
    }
}
