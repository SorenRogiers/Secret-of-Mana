using UnityEngine;

/* GAME MANAGER
 * ************
 * Creates all the other managers
 * Holds all the static information
 * Holds inventory - Handles input
 * Creates visual prefabs based on information from other managers
 */
public class GameManager : Singleton<GameManager> {

	public CharacterManager _characterManager { get; private set; }
    public Inventory _inventory { get; private set; }

    private void Awake()
    {
        Debug.Log("Creating other managers!");
        _characterManager = new CharacterManager();
        _inventory = new Inventory();
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
            _characterManager.SwitchCharacter();
        }
    }
}
