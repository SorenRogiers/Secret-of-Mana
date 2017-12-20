using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* GAME MANAGER
 * ************
 * Creates all the other managers
 * Holds all the static information
 * Holds inventory
 * Creates visual prefabs based on information from other managers
 */
public class GameManager : Singleton<GameManager> {

	public CharacterManager _characterManager { get; private set; }

    private void Awake()
    {
        Debug.Log("Creating other managers!");
        _characterManager = new CharacterManager();
    }
}
