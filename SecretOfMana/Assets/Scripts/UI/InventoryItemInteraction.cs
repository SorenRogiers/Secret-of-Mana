using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* INVENTORY_ITEM_INTERACTION
 * **************************
 * Equip or unequip items in the inventory by clicking on the item
 */
public class InventoryItemInteraction : MonoBehaviour, IPointerClickHandler
{
    private Character _selectedCharacter;
    private Text _textField;

    private void Start()
    {
        _selectedCharacter = GameManager.Instance().CharacterManager.SelectedCharacter;
        _textField = this.transform.GetChild(0).GetComponent<Text>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach(Item i in GameManager.Instance().Inventory.GetInventory())
        {
            if(_textField.text == i.Name)
            {
                if (i.Equipped)
                    _selectedCharacter.UnEquipItem(i);
                else
                    _selectedCharacter.EquipItem(i);
            }
        }

        GameManager.Instance().UIManager.InventoryPanel.Refresh();
    }
}
