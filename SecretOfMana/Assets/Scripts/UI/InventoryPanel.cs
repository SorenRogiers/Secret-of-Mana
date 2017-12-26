using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/* INVENTORYPANEL
 * **************
 * Shows the current items in the inventory
 * Shows the items equipped by the current active character
 */
public class InventoryPanel : ManaPanel
{
    private GameObject _itemPlaceHolderPrefab;
    private Character _selectedCharacter;
    private List<GameObject> _items;

    public override void Initialise()
    {
        _items = new List<GameObject>();
        _itemPlaceHolderPrefab = Resources.Load<GameObject>("Prefabs/UI/ItemPlaceholder");
    }

    public override void Refresh()
    {
        _selectedCharacter = GameManager.Instance().CharacterManager.SelectedCharacter;
        var inventory = GameManager.Instance().Inventory.GetInventory();

        //Clear the panel
        foreach (GameObject itemPanel in _items)
            Destroy(itemPanel);

        int xPos = -80;
        int yPosEquipped = 180;
        int yPosUnEquipped = 30;

        //For every item that is equipped, instantiate an item place holder
        //If the item type is a weapon use blue color
        //display the name of the item
        foreach (Item i in inventory)
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
            //Show only the equipped items of the selected character.
            if (i.Equipped && i.EquippedBy == _selectedCharacter.CharacterType)
            {
                itemPanel.transform.localPosition = new Vector2(xPos, yPosEquipped);
                yPosEquipped -= 30;
            }
            else if(!i.Equipped)
            {
                itemPanel.transform.localPosition = new Vector2(xPos, yPosUnEquipped);
                yPosUnEquipped -= 30;
            }

            //Add all the instantiated objects to a list.
            _items.Add(itemPanel);
        }
    }
}
