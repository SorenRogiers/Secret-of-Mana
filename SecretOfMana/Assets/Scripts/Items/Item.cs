/* ITEM
 * ****
 * Abstract class
 * contains Type ( Weapon - Armor) and Amount
 */
public abstract class Item
{
	public enum ItemTypes
    {
        Weapon,
        Armor
    }

    //MEMBERS
    //*******
    public int Amount { get; set; }
    public string Name { get; protected set; }
    public ItemTypes ItemType { get; protected set; }
    public int Attack { get; protected set; }
    public int Defense { get; protected set; }
    public bool Equipped { get; set; }
}
