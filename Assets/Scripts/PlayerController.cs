using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveInput;

    private Rigidbody2D playerRb;

    public Vector2 lastMoveInput;


    //Hash References for Animator
    private Animator playerAnimController;

    public int MoveInputXHash = Animator.StringToHash("MoveInputX");
    public int MoveInputYHash = Animator.StringToHash("MoveInputY");
    public int isMovingHash = Animator.StringToHash("isMoving");

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();

        playerAnimController = GetComponentInChildren<Animator>();
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        playerRb.MovePosition(playerRb.position + moveInput * moveSpeed * Time.fixedDeltaTime);

        HandlePlayerAnimations();

        GetLastMoveInput();
    }

    private void HandlePlayerAnimations()
    {
        if (moveInput != Vector2.zero)
        {
            playerAnimController.SetFloat(MoveInputXHash, moveInput.x);
            playerAnimController.SetFloat(MoveInputYHash, moveInput.y);

            playerAnimController.SetBool(isMovingHash, true);
        }

        else
        {
            playerAnimController.SetBool(isMovingHash, false);
        }
    }

    private void GetLastMoveInput()
    {
        if (moveInput != Vector2.zero)
        {
            //Debug.Log($"X: {lastMoveInputX}, Y {lastMoveInputY}");

            lastMoveInput = moveInput;
            
        }
    }

}
