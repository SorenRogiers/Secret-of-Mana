using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<Item> _itemList;

    public Inventory()
    {
        _itemList = new List<Item>();
    }
	
    public void AddItem(Item item, int amount = 1)
    {
        item.Amount = amount;
        _itemList.Add(item);
    }

    public void RemoveItem(Item item,int amount = 1)
    {
        //using Linq
        //Find the item in the list and substract the amount
        //if the amount <= 0 we remove the item from the list

        var foundItem = _itemList.FirstOrDefault(i => i.Name == item.Name);
        if(foundItem != null)
        {
            foundItem.Amount -= amount;

            if (foundItem.Amount <= 0)
                _itemList.Remove(foundItem);
        }
    }
}
