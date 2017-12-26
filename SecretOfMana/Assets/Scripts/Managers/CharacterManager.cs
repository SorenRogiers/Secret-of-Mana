using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/* CHARACTER MANAGER
 * *****************
 * Holds a list of characters and enemies
 * Holds the current selected character
 * Has functionality to switch between characters
 */
public class CharacterManager
{
    //MEMBERS
    //*******
    private List<Character> _characterList = new List<Character>();
    private List<Character> _enemyList = new List<Character>();

    public Character SelectedCharacter { get; private set; }

    private Transform _heroSpawnPosition;
    private Transform _girlSpawnPosition;
    private Transform _spriteSpawnPosition;
    private Transform _enemieSpawnPositions;

    private int _characterIndex = 0;

    //METHODS
    //*******
    public CharacterManager()
    {
        CreatePlayers();
        CreateEnemies();
    }

    public void SwitchCharacter()
    {
        //Set the current character to false
        SelectedCharacter.IsActive = false;

        if (_characterIndex >= _characterList.Count - 1)
            _characterIndex = 0;
        else
            _characterIndex++;

        //Get the next character in the list and set it as selected character
        SelectedCharacter = _characterList[_characterIndex];

        //Set it to active again and give the camera a new target
        SelectedCharacter.IsActive = true;
        Camera.main.GetComponent<PlayerCamera>().SetCameraTarget(SelectedCharacter.VisualCharacter.transform);

        //Update the new Target the inactive characters have to follow
        foreach(Character c in _characterList)
        {
            if (c.IsActive == false)
                (c.VisualCharacter as Character_PlayerBehaviour).Target = SelectedCharacter.VisualCharacter.transform;
        }
    }

    public List<Character> CharacterList
    {
        get { return _characterList; }
    }

    public List<Character> EnemyList
    {
        get { return _enemyList; }
    }

    private void CreatePlayers()
    {
        _heroSpawnPosition = GameObject.Find("Hero_SpawnPosition").transform;
        _girlSpawnPosition = GameObject.Find("Girl_SpawnPosition").transform;
        _spriteSpawnPosition = GameObject.Find("Sprite_SpawnPosition").transform;

        //Create the Hero character and add it to the characterlist
        var heroCharacter = new Character_Player(Character.Characters.HERO);
        heroCharacter.IsActive = true;
        heroCharacter.VisualCharacter.transform.position = _heroSpawnPosition.position;
        _characterList.Add(heroCharacter);

        //Create the Girl character and add it to the characterlist
        var girlCharacter = new Character_Player(Character.Characters.GIRL);
        (girlCharacter.VisualCharacter as Character_PlayerBehaviour).Target = heroCharacter.VisualCharacter.transform;
        girlCharacter.VisualCharacter.transform.position = _girlSpawnPosition.position;
        _characterList.Add(girlCharacter);

        //Create the Sprite character and add it to the characterlist
        var spriteCharacter = new Character_Player(Character.Characters.SPRITE);
        (spriteCharacter.VisualCharacter as Character_PlayerBehaviour).Target = heroCharacter.VisualCharacter.transform;
        spriteCharacter.VisualCharacter.transform.position = _spriteSpawnPosition.position;
        _characterList.Add(spriteCharacter);

        //Set selected character to hero
        SelectedCharacter = heroCharacter;

        //Set the camera to the selected character.
        Camera.main.GetComponent<PlayerCamera>().SetCameraTarget(SelectedCharacter.VisualCharacter.transform);
    }

    private void CreateEnemies()
    {
        _enemieSpawnPositions = GameObject.Find("Enemy_SpawnPositions").transform;

        //Create a new enemy for every transform found in _enemiesSpawnPosition
        foreach(Transform spawn in _enemieSpawnPositions)
        {
            var enemy = new Character_Enemy(Character.Characters.ENEMY);
            enemy.VisualCharacter.transform.position = spawn.position;
            enemy.VisualCharacter.transform.rotation = spawn.rotation;
            _enemyList.Add(enemy);
        }
    }
}
