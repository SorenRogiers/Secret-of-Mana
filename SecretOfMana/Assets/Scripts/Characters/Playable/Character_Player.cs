using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CHARACTER_PLAYER
 * ****************
 * Derives from Character
 * Determine the prefab depending on the Character
 * Instantiate Prefab
 */
public class Character_Player : Character
{
    //MEMBERS
    //*******
    private string _prefabPath;

    //METHODS
    //*******
    public Character_Player()
    {
    }
	
    public void DetermineCharacter(Characters characterType)
    {
        switch (characterType)
        {
            case Characters.HERO:
                Name = "Hero";
                _prefabPath = "Prefabs/Hero";
                break;
            case Characters.GIRL:
                Name = "Girl";
                _prefabPath = "Prefabs/Girl";
                break;
            case Characters.SPRITE:
                Name = "Sprite";
                _prefabPath = "Prefabs/Sprite";
                break;
            default:
                goto case Characters.HERO;
        }

        CharacterType = characterType;

        InstantiateCharacter();
    }

    private void InstantiateCharacter()
    {
        var characterPrefab = Resources.Load<VisualCharacter>(_prefabPath);
        _visualCharacter = Object.Instantiate(characterPrefab);
        _visualCharacter.gameObject.name = Name;
        
    }
}
