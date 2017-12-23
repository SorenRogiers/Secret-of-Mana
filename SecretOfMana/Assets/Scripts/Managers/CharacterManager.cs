﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private Character _selectedCharacter;

    private GameObject _heroSpawnPosition;
    private GameObject _girlSpawnPosition;
    private GameObject _spriteSpawnPosition;

    private int _characterIndex = 0;

    //METHODS
    //*******
    public CharacterManager()
    {
        _heroSpawnPosition = GameObject.Find("Hero_SpawnPosition");
        _girlSpawnPosition = GameObject.Find("Girl_SpawnPosition");
        _spriteSpawnPosition = GameObject.Find("Sprite_SpawnPosition");

        //Create the Hero character and add it to the characterlist
        var heroCharacter = new Character_Player(Character.Characters.HERO);
        heroCharacter.IsActive = true;
        heroCharacter.VisualCharacter.transform.position = _heroSpawnPosition.transform.position;
        _characterList.Add(heroCharacter);

        //Create the Girl character and add it to the characterlist
        var girlCharacter = new Character_Player(Character.Characters.GIRL);
        (girlCharacter.VisualCharacter as Character_PlayerBehaviour).Target = heroCharacter.VisualCharacter.transform;
        girlCharacter.VisualCharacter.transform.position = _girlSpawnPosition.transform.position;
        _characterList.Add(girlCharacter);

        //Create the Sprite character and add it to the characterlist
        var spriteCharacter = new Character_Player(Character.Characters.SPRITE);
        (spriteCharacter.VisualCharacter as Character_PlayerBehaviour).Target = heroCharacter.VisualCharacter.transform;
        spriteCharacter.VisualCharacter.transform.position = _spriteSpawnPosition.transform.position;
        _characterList.Add(spriteCharacter);

        //Set selected character to hero
        _selectedCharacter = heroCharacter;

        //Set camera for now
        Camera.main.GetComponent<PlayerCamera>().SetCameraTarget(_selectedCharacter.VisualCharacter.transform);
    }

    public void SwitchCharacter()
    {
        //Set the current character to false
        _selectedCharacter.IsActive = false;

        if (_characterIndex >= _characterList.Count - 1)
            _characterIndex = 0;
        else
            _characterIndex++;

        //Get the next character in the list and set it as selected character
        _selectedCharacter = _characterList[_characterIndex];

        //Set it to active again and give the camera a new target
        _selectedCharacter.IsActive = true;
        Camera.main.GetComponent<PlayerCamera>().SetCameraTarget(_selectedCharacter.VisualCharacter.transform);

        //Update the new Target the inactive characters have to follow
        foreach(Character c in _characterList)
        {
            if (c.IsActive == false)
                (c.VisualCharacter as Character_PlayerBehaviour).Target = _selectedCharacter.VisualCharacter.transform;
        }
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
