using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : ManaPanel
{
    private Text _InventoryText;

    public override void Initialise()
    {
        _InventoryText = GameObject.Find("InventoryText").GetComponent<Text>();
    }

    public override void Refresh()
    {
        StringBuilder inventoryString = new StringBuilder();
        inventoryString.Append("TODO - Place inventory here");
        _InventoryText.text = inventoryString.ToString();
    }
}
