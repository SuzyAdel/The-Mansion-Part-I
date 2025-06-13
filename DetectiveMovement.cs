using UnityEngine;

public class DetectiveMovement : MonoBehaviour
{
    [Header("References")]
    public Animator animator;                // Reference to the Animator component
    public RockThrower rockThrower;          // Reference to the RockThrower script
    public CharacterController characterController; // Reference to CharacterController

    [Header("Movement Settings")]
    public float walkSpeed = 3f;             // Walking speed
    public float runSpeed = 6f;              // Running speed

    private Vector3 movementInput;
    private bool isRunning = false;
    private bool isThrowing = false;
    private float currentSpeed;

    // use awake method to initialize components
    private void Awake()
    {
        if (characterController == null)
            characterController = GetComponent<CharacterController>();
            
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor for gameplay
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can go here if needed
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrowing) return;

        HandleMovementInput();
        HandleRunningInput();
        HandleThrowingInput();
        MoveCharacter();
        UpdateAnimator();
    }

    private void HandleMovementInput()// Handles WASD movement input
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementInput = new Vector3(horizontal, 0, vertical).normalized;
    }

    private void HandleRunningInput() // Handles running input with Left Shift key
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);
        currentSpeed = isRunning ? runSpeed : walkSpeed;
    }

    private void HandleThrowingInput() // Handles throwing input with Left Mouse Button
    {
        if (Input.GetMouseButtonDown(0) && !isThrowing && rockThrower.currentRocks > 0)
        {
            isThrowing = true;
            animator.SetBool("Throw", true); // Start throw animation
        }
    }

    private void MoveCharacter() // Makes the character move based on input and speed
    {
        Vector3 moveDirection = transform.TransformDirection(movementInput) * currentSpeed;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void UpdateAnimator() // Updates animator parameters based on movement state
    {
        bool isMoving = movementInput.magnitude > 0.1f;
        animator.SetBool("Walk", isMoving);
        animator.SetFloat("Velocity", isMoving ? (isRunning ? 1f : 0.5f) : 0f);
    }

    // Called from animation at peak throw moment to actually throw the rock EVENT
    public void ThrowForce(int trigger)
    {
        if (trigger == 1 && rockThrower != null)
        {
            rockThrower.ThrowRock(); // Delegate actual throw to RockThrower script
        }
    }

    // Called from animation when hand returns to side, EVENT 
    public void EndThrow()
    {
        isThrowing = false;
        animator.SetBool("Throw", false); // Reset animation state
    }
}