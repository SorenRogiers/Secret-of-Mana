using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : ManaPanel
{
    private Text _endGameText;

    public override void Initialise()
    {
        _endGameText = GameObject.Find("EndGameText").GetComponent<Text>();
    }

    public override void Refresh()
    {
       
    }

    public void Show(bool GameWon)
    {
        this.gameObject.SetActive(true);

        if(GameWon)
        {
            _endGameText.text = "Congratulations, YOU WON!";
        }
        else
        {
            _endGameText.text = "Game Over!";
        }
    }
}
