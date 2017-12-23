/* ITEM
 * ****
 * Abstract class
 * contains Type ( Weapon - Armor) and Amount
 */
public abstract class Item
{
	public enum ItemType
    {
        Weapon,
        Armor
    }

    //MEMBERS
    //*******
    public int Amount { get; set; }
    public string Name { get; protected set; }

    private ItemType _itemType;

    //METHODS
    //*******
    public ItemType GetItemType()
    {
        return _itemType;
    }

    protected void SetItemType(ItemType type)
    {
        _itemType = type;
    }
}
