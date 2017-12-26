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
        public GameObject Root;
        public Text HealthText;
        public Image Healthbar;
        public Character CharacterData;

        public void Refresh()
        {
            //Update the ui elements with the current character data
            HealthText.text = CharacterData.Health + " / " + CharacterData.MaxHealth;

            float health = CharacterData.Health;
            float maxHealth = CharacterData.MaxHealth;

            Healthbar.fillAmount = health / maxHealth;
        }
    }

    private CharacterUI _heroPanel;
    private CharacterUI _girlPanel;
    private CharacterUI _spritePanel;

    private void Start()
    {
        //Creating a character UI object for every character.

        _heroPanel = new CharacterUI { };
        _heroPanel.Root = GameObject.Find("HeroPanel");
        _heroPanel.HealthText = _heroPanel.Root.transform.Find("HealthText").GetComponent<Text>();
        _heroPanel.Healthbar = _heroPanel.Root.transform.Find("Healthbar").GetComponent<Image>();
        _heroPanel.CharacterData = GameManager.Instance().CharacterManager.CharacterList.FirstOrDefault(x => x.CharacterType == Character.Characters.HERO);
        

        _girlPanel = new CharacterUI { };
        _girlPanel.Root = GameObject.Find("GirlPanel");
        _girlPanel.HealthText = _girlPanel.Root.transform.Find("HealthText").GetComponent<Text>();
        _girlPanel.Healthbar = _girlPanel.Root.transform.Find("Healthbar").GetComponent<Image>();
        _girlPanel.CharacterData = GameManager.Instance().CharacterManager.CharacterList.FirstOrDefault(x => x.CharacterType == Character.Characters.GIRL);

        _spritePanel = new CharacterUI { };
        _spritePanel.Root = GameObject.Find("SpritePanel");
        _spritePanel.HealthText = _spritePanel.Root.transform.Find("HealthText").GetComponent<Text>();
        _spritePanel.Healthbar = _spritePanel.Root.transform.Find("Healthbar").GetComponent<Image>();
        _spritePanel.CharacterData = GameManager.Instance().CharacterManager.CharacterList.FirstOrDefault(x => x.CharacterType == Character.Characters.SPRITE);
    }

    private void Update()
    {
        _heroPanel.Refresh();
        _girlPanel.Refresh();
        _spritePanel.Refresh();
    }
}
