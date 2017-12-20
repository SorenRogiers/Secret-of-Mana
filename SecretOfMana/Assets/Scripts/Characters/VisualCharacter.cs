
using UnityEngine;

public class VisualCharacter : MonoBehaviour
{
    private Character _character;

   public Character GetCharacter()
    {
        return _character;
    }

    public void SetCharacter(Character character)
    {
        _character = character;
    }
}
