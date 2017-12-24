using UnityEngine.UI;
using UnityEngine;
using System.Text;

public class CharacterPanel : ManaPanel
{
    private Character _selectedCharacter;
    private Text _characterStatsText;
    private Image _activeCharacterImage;

    public override void Initialise()
    {
        _selectedCharacter = GameManager.Instance().CharacterManager.SelectedCharacter;

        _characterStatsText = GameObject.Find("CharacterStatsText").GetComponent<Text>();
        _activeCharacterImage = GameObject.Find("ActiveCharacterImage").GetComponent<Image>();
    }

    public override void Refresh()
    {
        _selectedCharacter = GameManager.Instance().CharacterManager.SelectedCharacter;

        switch (_selectedCharacter.CharacterType)
        {
            case Character.Characters.HERO:
                _activeCharacterImage.color = new Color(0.6f, 0.3f, 0.0f, 1.0f);
                break;
            case Character.Characters.GIRL:
                _activeCharacterImage.color = Color.yellow;
                break;
            case Character.Characters.SPRITE:
                _activeCharacterImage.color = Color.blue;
                break;
        }

        StringBuilder statsString = new StringBuilder();
        statsString.Append("Name: " + _selectedCharacter.Name + "\n");
        statsString.Append("Health:" + _selectedCharacter.Health + "/" + _selectedCharacter.MaxHealth + "\n");
        statsString.Append("Attack:" + _selectedCharacter.Attack + "\n");
        statsString.Append("Defense:" + _selectedCharacter.Defense + "\n");

        _characterStatsText.text = statsString.ToString();
    }
}
