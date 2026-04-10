using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [Header("Manager References")]
    public PlayerController playerController;
    public LevelManager levelManager;
    public UIManager uiManager;

    // public accessors for each system to allow other scripts to easily access them

    public PlayerController PlayerController => playerController;
    public UIManager UIManager => uiManager;
    public LevelManager LevelManager => levelManager;
   
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
