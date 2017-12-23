using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CHARACTER_PLAYER
 * ****************
 * Derives from Character
 */
public class Character_Player : Character
{
    private string _prefabPath;

    public Character_Player(Characters characterType)
    {
        Attack = 5;
        Defense = 5;
        CharacterType = characterType;

        DetermineCharacterModel(characterType);
    }

    private void DetermineCharacterModel(Characters characterType)
    {
        //Load the correct prefab depending on the characterType
        switch (CharacterType)
        {
            case Character.Characters.HERO:
                Name = "Hero";
                _prefabPath = "Prefabs/Hero";
                break;
            case Character.Characters.GIRL:
                Name = "Girl";
                _prefabPath = "Prefabs/Girl";
                break;
            case Character.Characters.SPRITE:
                Name = "Sprite";
                _prefabPath = "Prefabs/Sprite";
                break;
            default:
                goto case Character.Characters.HERO;
        }

        InstantiateCharacter();
    }

    private void InstantiateCharacter()
    {
        var characterPrefab = Resources.Load<VisualCharacter>(_prefabPath);
        VisualCharacter = Object.Instantiate(characterPrefab);
        VisualCharacter.gameObject.name = Name;
        (_visualCharacter as Character_PlayerBehaviour).SetCharacter(this);
    }
}
