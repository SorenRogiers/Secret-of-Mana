using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CHARACTER MANAGER
 * *****************
 * Holds a list of characters and enemies
 * Holds the current selected character
 * Has functionality to switch between characters
 */
public class CharacterManager
{
    //MEMBERS
    //*******
    private List<Character> _characterList = new List<Character>();
    private List<Character> _enemyList = new List<Character>();

    //private Character _selectedCharacter;
    private GameObject _spawnPosition;

    //METHODS
    //*******
    public CharacterManager()
    {
        _spawnPosition = GameObject.Find("Player_SpawnPosition");

        //Create the Hero character and add it to the characterlist
        var heroCharacter = new Character_Player();
        heroCharacter.DetermineCharacter(Character.Characters.HERO);
        heroCharacter.VisualCharacter.transform.position = _spawnPosition.transform.position;
        _characterList.Add(heroCharacter);


        //Set camera for now
        Camera.main.GetComponent<PlayerCamera>().SetCameraTarget(heroCharacter.VisualCharacter.transform);
    }

    public List<Character> CharacterList
    {
        get { return _characterList; }
    }

    public List<Character> EnemyList
    {
        get { return _enemyList; }
    }
}
