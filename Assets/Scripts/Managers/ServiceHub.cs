using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [Header("Manager References")]
    public PlayerController playerController;
    public LevelManager levelManager;
    public GameStateManager gameStateManager;
    public UIManager uiManager;

    private void Awake()
    {
        #region Singleton Pattern

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        #endregion
    }
}
