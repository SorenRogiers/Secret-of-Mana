using UnityEngine;

/* GAME MANAGER
 * ************
 * Creates all the other managers
 * Holds all the static information
 * Holds inventory - Handles input
 * Creates visual prefabs based on information from other managers
 */
public class GameManager : Singleton<GameManager> {

	public CharacterManager CharacterManager { get; private set; }
    public Inventory Inventory { get; private set; }
    public UIManager UIManager { get; private set; }

    private void Awake()
    {
        Debug.Log("Creating other managers!");
        CharacterManager = new CharacterManager();
        Inventory = new Inventory();
        UIManager = new UIManager();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        //Switch to different character
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CharacterManager.SwitchCharacter();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            UIManager.CharacterPanel.Toggle();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            UIManager.inventoryPanel.Toggle();
        }
    }
}
