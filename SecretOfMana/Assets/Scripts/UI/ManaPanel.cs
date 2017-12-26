using UnityEngine;

public abstract class ManaPanel : MonoBehaviour
{
    public abstract void Initialise();
    public abstract void Refresh();

    protected bool _isPanelActive = false;

    private void Start()
    {
        gameObject.SetActive(_isPanelActive);
    }

    public void Toggle()
    {
        //Refresh to get the newest character stats and toggle the panel on or off.
        Refresh();

        _isPanelActive = !_isPanelActive;

        this.gameObject.SetActive(_isPanelActive);

        if (_isPanelActive)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }
}
