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

        //Build a string with all the stats of the active character and show them in the textfield.
        StringBuilder statsString = new StringBuilder();
        statsString.Append("Name: " + _selectedCharacter.Name + "\n");
        statsString.Append("Health:" + _selectedCharacter.Health + "/" + _selectedCharacter.MaxHealth + "\n");
        statsString.Append("Attack:" + _selectedCharacter.Attack + "\n");
        statsString.Append("Defense:" + _selectedCharacter.Defense + "\n");
        

        string weaponString = _selectedCharacter.Weapon == null ? "None" : _selectedCharacter.Weapon.Name;
        statsString.Append("Weapon: " + weaponString + "\n");

        string weaponAtkString = _selectedCharacter.Weapon == null ? "0" : _selectedCharacter.Weapon.Attack.ToString();
        statsString.Append("Weapon Atk:" + weaponAtkString + "\n");

        string helmString = _selectedCharacter.Helm == null ? "None" : _selectedCharacter.Helm.Name;
        statsString.Append("Helm: " + helmString + "\n");

        string chestString = _selectedCharacter.Chest == null ? "None" : _selectedCharacter.Chest.Name;
        statsString.Append("Chest: " + chestString + "\n");

        string bracerString = _selectedCharacter.Bracers == null ? "None" : _selectedCharacter.Bracers.Name;
        statsString.Append("Bracers: " + bracerString + "\n");

        string helmDefense = _selectedCharacter.Helm == null ? "0" : _selectedCharacter.Helm.Defense.ToString();
        statsString.Append("Helm Defense:" + helmDefense + "\n");

        string chestDefense = _selectedCharacter.Chest == null ? "0" : _selectedCharacter.Chest.Defense.ToString();
        statsString.Append("Chest Defense:" + chestDefense + "\n");

        string bracerDefense = _selectedCharacter.Bracers == null ? "0" : _selectedCharacter.Bracers.Defense.ToString();
        statsString.Append("Bracer Defense:" + bracerDefense + "\n");

        _characterStatsText.text = statsString.ToString();
    }
}
