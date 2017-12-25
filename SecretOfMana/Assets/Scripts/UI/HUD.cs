using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HUD : MonoBehaviour
{ 
    /* CharacterUI struct
     * Holds a TextField
     * Holds an Image
     * Holds Character data
     */ 
    struct CharacterUI
    {
        public GameObject _root;
        public Text _text;
        public Image _healthbar;
        public Character _character;

        public void Refresh()
        {
            //Update the ui elements with the current character data
            _text.text = _character.Health + " / " + _character.MaxHealth;

            float health = _character.Health;
            float maxHealth = _character.MaxHealth;

            _healthbar.fillAmount = health / maxHealth;
        }
    }

    private CharacterUI _heroPanel;
    private CharacterUI _girlPanel;
    private CharacterUI _spritePanel;

    private void Start()
    {
        //Creating a character UI object for every character.

        _heroPanel = new CharacterUI { };
        _heroPanel._root = GameObject.Find("HeroPanel");
        _heroPanel._text = _heroPanel._root.transform.Find("HealthText").GetComponent<Text>();
        _heroPanel._healthbar = _heroPanel._root.transform.Find("Healthbar").GetComponent<Image>();
        _heroPanel._character = GameManager.Instance().CharacterManager.CharacterList.Where(x => x.CharacterType == Character.Characters.HERO).SingleOrDefault();
        

        _girlPanel = new CharacterUI { };
        _girlPanel._root = GameObject.Find("GirlPanel");
        _girlPanel._text = _girlPanel._root.transform.Find("HealthText").GetComponent<Text>();
        _girlPanel._healthbar = _girlPanel._root.transform.Find("Healthbar").GetComponent<Image>();
        _girlPanel._character = GameManager.Instance().CharacterManager.CharacterList.Where(x => x.CharacterType == Character.Characters.GIRL).SingleOrDefault();

        _spritePanel = new CharacterUI { };
        _spritePanel._root = GameObject.Find("SpritePanel");
        _spritePanel._text = _spritePanel._root.transform.Find("HealthText").GetComponent<Text>();
        _spritePanel._healthbar = _spritePanel._root.transform.Find("Healthbar").GetComponent<Image>();
        _spritePanel._character = GameManager.Instance().CharacterManager.CharacterList.Where(x => x.CharacterType == Character.Characters.SPRITE).SingleOrDefault();
    }

    private void Update()
    {
        _heroPanel.Refresh();
        _girlPanel.Refresh();
        _spritePanel.Refresh();
    }
}
