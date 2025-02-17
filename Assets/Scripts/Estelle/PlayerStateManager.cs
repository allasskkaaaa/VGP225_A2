using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static Player_InputHandler;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager Instance { get; private set; }

    PlayerBaseState currentState;
    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerMoveState moveState = new PlayerMoveState();
    public PlayerHideState hideState = new PlayerHideState();
    public PlayerJumpState jumpState = new PlayerJumpState();
    public PlayerHurtState hurtState = new PlayerHurtState();
    public PlayerDeathState deathState = new PlayerDeathState();

    private Vector2 direction2D;
    private Vector3 direction3D;

    public Vector3 velocity;
    private bool isGrounded;    

    [SerializeField] public float speed = 1f;
    [SerializeField] public float gravity = -9.81f;
    [SerializeField] public float jumpForce = 2f;  // Jump strength
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float animationTransitionDuration;
    [SerializeField] public float HideDuration;
    [SerializeField] public float HurtDuration;

    [SerializeField] private Transform camera;

    public CharacterController cc;
    private Animator animator;
    public bool IsHiding = false;
    public bool IsHurt = false;
    public float HideTimeLeft = 0;
    public float HurtTimeLeft = 0;

    public int playerMaxHealth = 6;
    public int playerHealth;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }

        Player_InputHandler.player_InputHandler.OnJumpPressed += playerJump;
        Player_InputHandler.player_InputHandler.OnHidePressed += playerHide;

        currentState = idleState;

        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        currentState.EnterState(this);

        playerHealth = playerMaxHealth;
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void PlayAnimation(string name)
    {
        animator.CrossFade(name, animationTransitionDuration);
    }

    private void FixedUpdate()
    {
        direction2D = Player_InputHandler.player_InputHandler.moveInput.ReadValue<Vector2>();

        Vector3 cameraForward = new Vector3(camera.forward.x, 0, camera.forward.z).normalized;
        Vector3 cameraRight = new Vector3(camera.right.x, 0, camera.right.z).normalized;

        direction3D = cameraForward * direction2D.y + cameraRight * direction2D.x;

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
        // Cannot move while hiding
        if (IsHiding || IsHurt)
            return;

        cc.Move(direction3D.normalized * speed * Time.deltaTime);

        if (direction3D.magnitude > 0.01f)
        {
            Vector3 laggingForward = Vector3.Slerp(cc.transform.forward, direction3D.normalized, Time.deltaTime * rotationSpeed);
            cc.transform.forward = laggingForward;
        }
    }
        

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime); // Apply gravity
    }

    public void playerHide()
    {
        currentState.OnHidePressed(this);
    }

    public void playerJump()
    {
        currentState.OnJumpPressed(this);
    }
    public void OnTriggerEnter(Collider other)
    {
        BroomCollider broomCollider = other.GetComponent<BroomCollider>();
        Chef_Projectile projectile = other.GetComponent<Chef_Projectile>();

        if (broomCollider != null || projectile != null || other.tag == "Cat")
        {
            // Did collide with broom collider
            Debug.Log("Damage");
            playerTakeDamage();
            IsHurt = true;
            SwitchState(hurtState);
        }

    }

    public void playerTakeDamage()
    {
        playerHealth -= 1;
        Debug.Log("the player health is: " + playerHealth);
        CanvasManager.instance.healthUI();
    }
}
