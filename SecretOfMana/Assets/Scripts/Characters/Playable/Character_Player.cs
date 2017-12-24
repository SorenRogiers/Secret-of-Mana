using UnityEngine;
/* CHARACTER_PLAYER
 * ****************
 * Derives from Character
 */
public class Character_Player : Character
{
    public Character_Player(Characters characterType)
    {
        Attack = 5;
        Defense = 5;

        CharacterType = characterType;

        DetermineCharacterModel(characterType);

        (_visualCharacter as Character_PlayerBehaviour).SetCharacter(this);
    }
}
