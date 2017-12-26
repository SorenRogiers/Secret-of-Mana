using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

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

    public bool IsGameCompleted { get; set; }
    public bool IsGameOver { get; set; }

    private void Awake()
    {
        Debug.Log("Creating other managers!");
        CharacterManager = new CharacterManager();
        Inventory = new Inventory();
        UIManager = new UIManager();

    }

    private void Start()
    {
        AddStarterItems();
    }

    private void Update()
    {
        HandleInput();

        if (IsGameCompleted)
        {
            Time.timeScale = 0.0f;
            UIManager.EndGamePanel.Show(true);
        }
        else if(IsGameOver)
        {
            UIManager.EndGamePanel.Show(false);
            Time.timeScale = 0.0f;
        }

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
            UIManager.InventoryPanel.Toggle();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            CharactersHalfHP();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            HealAllCharacters();
        }

    }

    private void AddStarterItems()
    {
        var rustySword = new Weapon_Sword("Rusty Sword", 3);
        var shortBow = new Weapon_Bow("Short Bow", 4);
        var LightsWrath = new Weapon_Staff("Light's Wrath");

        var overall = new Armor_Chest("Overall", 1);
        var chainVest = new Armor_Chest("Chain Vest", 2);

        var bandana = new Armor_Helm("Bandana", 1);
        var dragonHelm = new Armor_Helm("Dragon Helm", 2);

        var wristBand = new Armor_Bracers("Wristband", 1);
        var cobraBracelet = new Armor_Bracers("Cobra Bracelet", 2);

        Inventory.AddItem(rustySword);
        Inventory.AddItem(shortBow);
        Inventory.AddItem(LightsWrath);
        Inventory.AddItem(overall);
        Inventory.AddItem(chainVest);
        Inventory.AddItem(bandana);
        Inventory.AddItem(dragonHelm);
        Inventory.AddItem(wristBand);
        Inventory.AddItem(cobraBracelet);

        CharacterManager.SelectedCharacter.EquipItem(rustySword);
        CharacterManager.CharacterList.FirstOrDefault(x => x.CharacterType == Character.Characters.GIRL).EquipItem(shortBow);
        CharacterManager.CharacterList.FirstOrDefault(x => x.CharacterType == Character.Characters.SPRITE).EquipItem(LightsWrath);
    }
    private void CharactersHalfHP()
    {
        CharacterManager.CharacterList.ForEach(x => x.TakeDamage(x.MaxHealth / 2));
    }

    private void HealAllCharacters()
    {
        CharacterManager.CharacterList.ForEach(x => x.Heal(x.MaxHealth));
    }
}
