using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowShooter : MonoBehaviour
{
    public GameObject arrow;

    public Transform firePoint;

    public void OnShoot(InputValue value)
    {
        Instantiate(arrow, firePoint.position, firePoint.rotation);
        
    }
}
