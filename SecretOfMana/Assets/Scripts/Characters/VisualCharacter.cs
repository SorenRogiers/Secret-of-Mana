using UnityEngine;

/* VISUALCHARACTER
 * ***************
 * Member of Character.
 * Link from UI to Logic.
 * Determine the model of the character and whether it's active or not.
 */
public class VisualCharacter : MonoBehaviour
{
    //MEMBERS
    //*******
    protected bool _isActive = true;

    private Character _character;
    private string _prefabPath;

    //METHODS
    //*******
    public Character GetCharacter()
    {
        return _character;
    }

    public void SetCharacter(Character character, Character.Characters characterType)
    {
        _character = character;

        //Load the correct prefab depending on the characterType
        switch (characterType)
        {
            case Character.Characters.HERO:
                _character.Name = "Hero";
                _prefabPath = "Prefabs/Hero";
                break;
            case Character.Characters.GIRL:
                _character.Name = "Girl";
                _prefabPath = "Prefabs/Girl";
                break;
            case Character.Characters.SPRITE:
                _character.Name = "Sprite";
                _prefabPath = "Prefabs/Sprite";
                break;
            default:
                goto case Character.Characters.HERO;
        }

        _character.CharacterType = characterType;

        InstantiateCharacter();
    }

    private void InstantiateCharacter()
    {
        var characterPrefab = Resources.Load<VisualCharacter>(_prefabPath);
        _character.VisualCharacter = Object.Instantiate(characterPrefab);
        _character.VisualCharacter.gameObject.name = _character. Name;
    }

    public void SetActive(bool isActive)
    {
        _isActive = isActive;
    }
}
