using UnityEngine;

/* VISUALCHARACTER
 * ***************
 * Member of Character.
 * Link from UI to Logic.
 */
public class VisualCharacter : MonoBehaviour
{
    //MEMBERS
    //*******
    protected Character _character;

    //METHODS
    //*******
    public Character GetCharacter(Character.Characters characterType)
    {
        return _character;
    }

    public void SetCharacter(Character character)
    {
        _character = character;
    }
}
