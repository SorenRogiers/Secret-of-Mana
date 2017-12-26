using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryPanel : ManaPanel
{
    private GameObject _itemPlaceHolderPrefab;

    public override void Initialise()
    {
        _itemPlaceHolderPrefab = Resources.Load<GameObject>("Prefabs/UI/ItemPlaceholder");
    }

    public override void Refresh()
    {
        var equippedItems = GameManager.Instance().Inventory.GetInventory();
        int xPos = -80;
        int yPosEquipped = 160;
        int yPosUnEquipped = 0;

        //For every item that is equipped, instantiate an item place holder
        //If the item type is a weapon use blue color
        //display the name of the item
        foreach (Item i in equippedItems)
        {
            //For every item in inventory, instantiate an item place holder
            var itemPanel = Object.Instantiate(_itemPlaceHolderPrefab);
            itemPanel.gameObject.name = "ItemPlaceHolder";
            itemPanel.transform.SetParent(this.transform);

            //Depending on the itemtype we set the color of the image
            if (i.ItemType == Item.ItemTypes.Weapon)
                itemPanel.GetComponent<Image>().color = Color.blue;
            else
                itemPanel.GetComponent<Image>().color = Color.green;

            //Set the name of the item as text
            itemPanel.transform.GetChild(0).GetComponent<Text>().text = i.Name;

            //Position the item higher or lower depending if its equipped or not.
            if (i.Equipped)
            {
                itemPanel.transform.localPosition = new Vector2(xPos, yPosEquipped);
                yPosEquipped -= 30;
            }
            else
            {
                itemPanel.transform.localPosition = new Vector2(xPos, yPosUnEquipped);
                yPosUnEquipped -= 30;
            }
        }
    }
}
