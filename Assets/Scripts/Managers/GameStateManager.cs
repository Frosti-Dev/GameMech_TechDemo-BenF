using UnityEngine;

public enum GameState
{
    None,
    Init,
    MainMenu,
    Gameplay,
    Paused,
    Options
}

public class GameStateManager : MonoBehaviour
{
    public UIManager uiManager;
    public LevelManager levelManager;

    public GameState currentState { get; private set; }

    public GameState previousState { get; private set; }

    [Header("Debug (read only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;


    private void Start()
    {
        SetState(GameState.Init);
    }

    public void SetState(GameState newState)
    {
        if (currentState == newState) return;
        previousState = currentState;
        currentState = newState;

        currentActiveState = currentState.ToString();
        previousActiveState = currentState.ToString();

        OnGameStateChanged(previousState, currentState);
    }
    private void OnGameStateChanged(GameState previousState, GameState currentState)
    {
        switch (currentState)
        {
            case GameState.None:
                Time.timeScale = 0f;
                Debug.Log("This should never come up");
                break;

            case GameState.Init:
                Debug.Log("Initializing Game...");

                //Run logic here

                Debug.Log("Initialization Complete!");
                Debug.Log("Exiting Init State...");
                Time.timeScale = 0f; //pauses game
                SetState(GameState.MainMenu);
                break;


            case GameState.MainMenu:
                Time.timeScale = 0f;
                Debug.Log("MainMenuStateLoaded!");

                levelManager.ResetLevel();
                uiManager.ShowMainMenuUI();
                break;

            case GameState.Gameplay:
                Time.timeScale = 1f;

                levelManager.currentActiveLevel.SetActive(true);
                uiManager.ShowGameplayUI();
                break;

            case GameState.Paused:
                Time.timeScale = 0f;

                uiManager.ShowPausedUI();
                break;

            case GameState.Options:
                Time.timeScale = 0f;

                uiManager.ShowOptionsUI();
                break;
        }
    }

    public void StartGame()
    {
        SetState(GameState.Gameplay);
    }

    public void TogglePause()
    {
        if (currentState == GameState.Paused)
        {
            //ignore if already gameplay
            if (currentState == GameState.Gameplay) return;

            SetState(GameState.Gameplay);
        }

        else if (currentState == GameState.Gameplay)
        {
            //ignore if already paused
            if (currentState == GameState.Paused) return;

            SetState(GameState.Paused);
        }
    }

    public void MainMenuButton()
    {
        SetState(GameState.MainMenu);
    }

    public void OptionButton()
    {
        SetState(GameState.Options);
    }

    public void ResumeButton()
    {
        SetState(previousState);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
