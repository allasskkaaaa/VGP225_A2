using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public class Player_InputHandler : MonoBehaviour
{
    public static Player_InputHandler player_InputHandler;

    public InputController inputController;

    public InputAction moveInput;
    public InputAction jumpInput;
    public InputAction hideInput;

    public delegate void JumpPressed();
    public event JumpPressed OnJumpPressed;

    public delegate void JumpReleased();
    public event JumpReleased OnJumpReleased;

    public delegate void HidePressed();
    public event HidePressed OnHidePressed;

    public delegate void HideReleased();
    public event HideReleased OnHideReleased;

    private void Awake()
    {
        if (player_InputHandler == null) player_InputHandler = this;

        inputController = new InputController();

        moveInput = inputController.PlayerMovement.Move;
        moveInput.Enable();

        jumpInput = inputController.PlayerMovement.Jump;
        jumpInput.Enable();
        jumpInput.performed += ctx => JumpIsPressed();
        jumpInput.canceled += ctx => JumpIsReleased();

        hideInput = inputController.PlayerMovement.Hide;
        hideInput.Enable();
        hideInput.performed += ctx => HideIsPressed();
        hideInput.canceled += ctx => HideIsReleased();


        inputController.Enable();

    }

    private void OnDisable()
    {
        moveInput?.Disable();
        jumpInput?.Disable();
        hideInput?.Disable();

        inputController.Disable();
    }
    private void OnDestroy()
    {
        OnJumpPressed -= JumpIsPressed;
        OnJumpReleased -= JumpIsReleased;

        OnHidePressed -= HideIsPressed;
        OnHideReleased -= HideIsReleased;

        inputController.Disable();
    }

    public void JumpIsPressed()
    {
        OnJumpPressed?.Invoke();
    }

    public void JumpIsReleased()
    {
        OnJumpReleased?.Invoke();
    }

    public void HideIsPressed()
    {
        OnHidePressed?.Invoke();
    }

    public void HideIsReleased()
    {
        OnHideReleased?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
