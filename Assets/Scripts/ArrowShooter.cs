using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowShooter : MonoBehaviour
{
    public Arrow arrow;

    public Transform firePoint;

    public PlayerController playerController;

    public void OnShoot(InputValue value)
    {
        Arrow GO = Instantiate(arrow, firePoint.position, firePoint.rotation);

        GO.Intialize(playerController.lastMoveInput);
        
    }
}
