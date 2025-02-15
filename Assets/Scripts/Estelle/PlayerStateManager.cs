using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static Player_InputHandler;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    PlayerIdleState idleState = new PlayerIdleState();
    PlayerMoveState moveState = new PlayerMoveState();  
    PlayerHideState hideState = new PlayerHideState();
    PlayerJumpState jumpState = new PlayerJumpState();

    private Vector2 direction2D;
    private Vector3 direction3D;

    private Vector3 velocity;
    private bool isGrounded;


    [SerializeField] public float speed = 1f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpForce = 2f;  // Jump strength

    private CharacterController cc;

    void Start()
    {
        Player_InputHandler.player_InputHandler.OnJumpPressed += playerJump;
        Player_InputHandler.player_InputHandler.OnHidePressed += playerHide;

        currentState = idleState;

        currentState.EnterState(this);

        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        currentState.UpdateState(this);

        
    }

    private void FixedUpdate()
    {
        direction2D = Player_InputHandler.player_InputHandler.moveInput.ReadValue<Vector2>();
        direction3D = new Vector3(direction2D.x, 0, direction2D.y);
        playerMove();
        ApplyGravity();

        isGrounded = cc.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset downward velocity to stick to the ground
        }
    }

    public void SwitchState (PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void playerMove()
    {
       cc.Move(direction3D * speed * Time.deltaTime);
      if(direction3D.magnitude > 0.01f)
        cc.transform.forward = direction3D;
    }
        

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime); // Apply gravity
    }

    public void playerHide()
    {
        Debug.Log("Player is Hiding");
    }

    public void playerJump()
    {
        if (!cc.isGrounded)
            return;

        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Apply jump force
    }

}
