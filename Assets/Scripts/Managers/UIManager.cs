using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject pausedUI;
    [SerializeField] private GameObject optionsUI;

    public void HideAllUI()
    {
        gameplayUI.SetActive(false);
        mainMenuUI.SetActive(false);
        pausedUI.SetActive(false);
        optionsUI.SetActive(false);

    }

    public void ShowMainMenuUI()
    {
        HideAllUI();
        mainMenuUI.SetActive(true);
    }

    public void ShowGameplayUI()
    {
        HideAllUI();
        gameplayUI.SetActive(true);
    }
    public void ShowPausedUI()
    {
        optionsUI.SetActive(false);
        pausedUI.SetActive(true);
    }

    public void ShowOptionsUI()
    {
        pausedUI.SetActive(false);
        optionsUI.SetActive(true);
    }

}
