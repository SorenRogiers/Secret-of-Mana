using UnityEngine;

/* CHARACTER_ENEMY
 * ***************
 * Derives from character
 */
public class Character_Enemy : Character
{
    public Character_Enemy(Characters characterType)
    {
        Attack = 8;
        Defense = 1;

        MaxHealth = 20;
        Health = MaxHealth;

        CharacterType = characterType;
        DetermineCharacterModel(characterType);

        (_visualCharacter as Character_EnemyBehaviour).SetCharacter(this);
    }

    protected override void Die()
    {
        Object.Destroy(_visualCharacter.gameObject);
    }
}
