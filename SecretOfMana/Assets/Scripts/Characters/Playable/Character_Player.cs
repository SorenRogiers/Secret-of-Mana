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
        Defense = 3;

        CharacterType = characterType;

        DetermineCharacterModel(characterType);

        (_visualCharacter as Character_PlayerBehaviour).SetCharacter(this);
    }

    protected override void Die()
    {
        GameManager.Instance().IsGameOver = true;
    }
}
