using UnityEngine;

public class DetectiveMovement : MonoBehaviour
{
    [Header("References")]
    public Animator animator;
    public RockThrower rockThrower;
    public CharacterController characterController;
    public AudioSource footstepAudioSource;  // For walk/run sounds default AudioSource

    [Header("Movement Settings")]
    public float walkSpeed = 3f;
    public float runSpeed = 6f;

    [Header("Footstep Sounds")]
    public AudioClip walkSound;  // Single walk sound
    public AudioClip runSound;   // Single run sound
    public float walkStepInterval = 0.5f;
    public float runStepInterval = 0.3f;

    [Header("Throw Sound")]
    public AudioClip throwSound;  // Single throw sound

    private Vector3 movementInput;
    private bool isRunning = false;
    private float currentSpeed;
    private float nextFootstepTime;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can go here if needed
    }

    // Update is called once per frame
    void Update()
    {
        //if (isThrowing) return;

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
        if (Input.GetMouseButtonDown(0) && rockThrower.currentRocks > 0)// && !isThrowing removed 
        {
            //isThrowing = true; Remove isThrowing check to allow throwing while moving, and multiple throwing 
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
        float speedPercent = isRunning ? 1f : 0.5f;
        Debug.Log($"Movement: {isMoving}, Running: {isRunning}, Speed: {speedPercent}");
        animator.SetBool("Walk", isMoving);
        animator.SetFloat("Velocity", isMoving ? speedPercent : 0f);
    }

    // Called from animation at peak throw moment to actually throw the rock EVENT
    public void ThrowForce(int trigger)
    {
        if (trigger == 1 && rockThrower != null)
        {
            if (throwSound != null)
                footstepAudioSource.PlayOneShot(throwSound); //modified to play sound at throw peak
            rockThrower.ThrowRock(); // Delegate actual throw to RockThrower script
        }
    }

    // Called from animation when hand returns to side, EVENT 
    public void EndThrow()
    {
        //isThrowing = false;
        animator.SetBool("Throw", false); // Reset animation state
    }

    public void PlayFootstep() // Called from animation event
    {
        if (Time.time > nextFootstepTime && footstepAudioSource != null)
        {
            if (isRunning && runSound != null)
            {
                footstepAudioSource.PlayOneShot(runSound);
                nextFootstepTime = Time.time + runStepInterval;
            }
            else if (!isRunning && walkSound != null)
            {
                footstepAudioSource.PlayOneShot(walkSound);
                nextFootstepTime = Time.time + walkStepInterval;
            }
        }
    }

}
