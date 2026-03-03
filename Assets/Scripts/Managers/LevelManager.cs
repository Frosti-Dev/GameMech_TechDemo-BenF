using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject level01;
    public GameObject level02;
    public GameObject level03;
    public GameObject level04;

    public GameObject currentActiveLevel;

    private GameObject player;

    public Vector3 initSpawn;

    private void Start()
    {
        player = ServiceHub.Instance.playerController.gameObject;

        initSpawn = player.transform.position;

        currentActiveLevel = level01;

        level01.SetActive(false);
        level02.SetActive(false);
        level03.SetActive(false);
        level04.SetActive(false);
    }

    public void LevelChange(GameObject Level, Transform SpawnPoint)
    {
        currentActiveLevel.SetActive(false);
        currentActiveLevel = Level;
        Level.SetActive(true);
        player.transform.position = SpawnPoint.position;
    }

    public void ResetLevel()
    {
        level01.SetActive(false);
        level02.SetActive(false);
        level03.SetActive(false);
        level04.SetActive(false);

        player.transform.position = initSpawn;

        currentActiveLevel = level01;
    }
}
