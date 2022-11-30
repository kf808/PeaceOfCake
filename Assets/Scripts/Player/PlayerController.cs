using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private PlayerControls playerControls;
    private Vector2 movementInput;    
    private Rigidbody2D _rigidbody;
    private Animator animator;
    private PlayerAttack playerAttack;
    private Weight playerWeight;
    private Health playerHealth;

    private float carryWeight;
    private bool isFacingRight = true;

    private void Awake()
    {
        playerControls = new PlayerControls();
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
        playerWeight = GetComponent<Weight>();
        playerHealth = GetComponent<Health>();
    }

    private void OnEnable()
    {
        playerControls.Player.Enable();
        EnableInputEvents();
    }

    private void OnDisable()
    {
        DisableInputEvents();
    }

    private void EnableInputEvents()
    {
        playerControls.Player.Move.performed += OnMove;
        playerControls.Player.Move.canceled += OnMove;

        playerControls.Player.Attack.performed += OnAttack;
        playerControls.Player.Attack.canceled += OnAttack;

        playerControls.Player.Interact.performed += OnInteract;
        playerControls.Player.Interact.canceled += OnInteract;
    }

    private void DisableInputEvents()
    {
        playerControls.Player.Disable();
        playerControls.Player.Move.performed -= OnMove;
        playerControls.Player.Move.canceled -= OnMove;

        playerControls.Player.Attack.performed -= OnAttack;
        playerControls.Player.Attack.canceled -= OnAttack;

        playerControls.Player.Interact.performed -= OnInteract;
        playerControls.Player.Interact.canceled -= OnInteract;
    }

    private void Update()
    {
        if (playerHealth.isDead)
            DisableInputEvents();

        if (movementInput != Vector2.zero)
        {
            animator.SetBool("IsMoving", true);
            if (movementInput.x < 0 && isFacingRight)
                FlipPlayer(180f);
            else if (movementInput.x > 0 && !isFacingRight)
                FlipPlayer(0f);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    private void FixedUpdate()
    {
        var playerSpeed = Mathf.Clamp(0f, (playerWeight.GetMinWeight() * movementSpeed) / (playerWeight.GetWeight() + carryWeight), float.MaxValue);
        var move = new Vector2(movementInput.x * playerSpeed * Time.deltaTime, movementInput.y * playerSpeed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + move);
    }

    private void FlipPlayer(float angle)
    {
        isFacingRight = !isFacingRight;
        transform.eulerAngles = new Vector3(0f, angle, 0f);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        AimMovement(mousePosition);

        movementInput = Vector2.zero;
        if (context.action.IsPressed())
        {
            animator.SetTrigger("Attack");
            playerAttack.Attack(mousePosition);
        }
        else
            animator.ResetTrigger("Attack");
    }

    private void AimMovement(Vector3 mousePosition)
    {
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(angle) < 90f && !isFacingRight)
            FlipPlayer(0f);
        else if(Mathf.Abs(angle) > 90f && isFacingRight)
            FlipPlayer(180f);
    }

    private void OnInteract(InputAction.CallbackContext context)
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Tags.Princess)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.transform.SetParent(gameObject.transform);
            collision.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
            carryWeight = collision.gameObject.GetComponent<Weight>().GetWeight();
            EventHandler.LevelExitOpen();
            EventHandler.RespawnEnemies();
        }
    }
}
