using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class GamepadPlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = -20f;

    [Header("Camera")]
    public Transform cameraPivot;
    public Transform _visual;
    public float lookSpeed = 120f;
    public float minY = -40f;
    public float maxY = 60f;

    private CharacterController controller;
    private PlayerInputActions input;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private float verticalVelocity;
    private float cameraY;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = new PlayerInputActions();

        input.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += _ => moveInput = Vector2.zero;

        input.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        input.Player.Look.canceled += _ => lookInput = Vector2.zero;

        input.Player.Jump.performed += _ => Jump();
        input.Player.Attack.performed += _ => Attack();
        input.Player.Parry.performed += _ => Parry();
        input.Player.Other.performed += _ => Other();
    }

    void OnEnable() => input.Enable();
    void OnDisable() => input.Disable();

    void Update()
    {
        Move();
        Look();
    }

    // ================= MOVE =================
    void Move()
    {
        Vector3 move = transform.forward * moveInput.y + transform.right * moveInput.x;
        move *= moveSpeed;

        if (controller.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;
        move.y = verticalVelocity;

        controller.Move(move * Time.deltaTime);
    }

    void Jump()
    {
        if (controller.isGrounded)
            verticalVelocity = jumpForce;
    }

    // ================= LOOK =================
    void Look()
    {
        transform.Rotate(Vector3.up * lookInput.x * lookSpeed * Time.deltaTime);

        cameraY -= lookInput.y * lookSpeed * Time.deltaTime;
        cameraY = Mathf.Clamp(cameraY, minY, maxY);
        cameraPivot.localRotation = Quaternion.Euler(cameraY, 0f, 0f);
        _visual.localRotation = Quaternion.Euler(-0, -cameraY, 0f);
    }

    // ================= ACTIONS =================
    void Attack()
    {
        Debug.Log("Attack");
    }

    void Parry()
    {
        Debug.Log("Parry");
    }

    void Other()
    {
        Debug.Log("Other");
    }
}
