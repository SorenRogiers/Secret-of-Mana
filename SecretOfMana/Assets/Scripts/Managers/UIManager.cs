using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* UI MANAGER
 * **********
 * Responsible to open panels
 * Keeps track of panels (members)
 * Initialize panels
 */
public class UIManager
{
    public CharacterPanel CharacterPanel { get; private set; }
    public InventoryPanel inventoryPanel { get; private set; }

    private Canvas _canvas;

    public UIManager()
    {
        _canvas = GameObject.Find("UI_Canvas").GetComponent<Canvas>();

        CreateCharacterPanel();
        CreateInventoryPanel();
    }
    
    private void CreateCharacterPanel()
    {
        //Locate the prefab and instantiate it - Set the canvas as parent
        var characterPanelPrefab = Resources.Load<CharacterPanel>("Prefabs/UI/CharacterPanel");
        CharacterPanel = GameObject.Instantiate(characterPanelPrefab);
        CharacterPanel.transform.SetParent(_canvas.transform);
        CharacterPanel.transform.localPosition = Vector3.zero;
        CharacterPanel.Initialise();
    }

    private void CreateInventoryPanel()
    {
        //Locate the prefab and instantiate it - Set the canvas as parent
        var InventoryPanelPrefab = Resources.Load<InventoryPanel>("Prefabs/UI/InventoryPanel");
        inventoryPanel = GameObject.Instantiate(InventoryPanelPrefab);
        inventoryPanel.transform.SetParent(_canvas.transform);
        inventoryPanel.transform.localPosition = Vector3.zero;
        inventoryPanel.Initialise();
    }
}
