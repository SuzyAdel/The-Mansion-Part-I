using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class CooperController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float followDistance = 25f;
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float stoppingDistance = 2f;
    public float acceleration = 12f;
    public float angularSpeed = 400f;

    [Header("Bark Settings")]
    public float barkDetectionRadius = 4f;
    public float minBarkInterval = 3f;
    public float maxBarkInterval = 8f;
    public AudioClip barkSound;
    public AudioClip callSound;

    private NavMeshAgent agent;
    private Animator animator;
    private AudioSource audioSource;
    private AudioSource callAudioSource;
    private Transform player;
    private Transform key;

    private enum DogState { Following, Returning, Searching, BarkingAtKey }
    private DogState currentState = DogState.Following;

    private float nextBarkTime;
    private bool isAtKey = false;
    private bool shouldPlayCallSound = false;
    private bool isBarking = false;
    private bool isCallSoundPlaying = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Create dedicated AudioSource for call sounds
        callAudioSource = gameObject.AddComponent<AudioSource>();
        callAudioSource.playOnAwake = false;
        callAudioSource.loop = false;

        audioSource.playOnAwake = false;
        audioSource.loop = false;

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        key = GameObject.FindGameObjectWithTag("Key")?.transform;

        if (player == null) Debug.LogError("Player not found! Assign 'Player' tag.");
        if (key == null) Debug.LogWarning("Key not found initially. Will search when available.");

        ConfigureAgent();
        SetNextBarkTime();
    }

    void ConfigureAgent()
    {
        agent.speed = walkSpeed;
        agent.acceleration = acceleration;
        agent.angularSpeed = angularSpeed;
        agent.stoppingDistance = stoppingDistance;
        agent.autoBraking = true;
    }

    void Update()
    {
        if (player == null) return;

        HandleInput();
        UpdateState();
        UpdateAnimations();
        HandleBarking();
        HandleCallSound();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ReturnToPlayer();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SearchForKey();
        }
    }

    void UpdateState()
    {
        switch (currentState)
        {
            case DogState.Following:
                UpdateFollowingState();
                break;
            case DogState.Returning:
                UpdateReturningState();
                break;
            case DogState.Searching:
                UpdateSearchingState();
                break;
            case DogState.BarkingAtKey:
                UpdateBarkingAtKeyState();
                break;
        }
    }

    void UpdateFollowingState()
    {
        agent.speed = walkSpeed;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            agent.SetDestination(player.position);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            agent.ResetPath();
            animator.SetBool("IsWalking", false);
            FaceTarget(player.position);
        }
    }

    void UpdateReturningState()
    {
        agent.speed = runSpeed;
        agent.SetDestination(player.position);
        animator.SetBool("IsWalking", true);

        if (Vector3.Distance(transform.position, player.position) <= stoppingDistance)
        {
            currentState = DogState.Following;
            shouldPlayCallSound = false;
            animator.SetBool("IsWalking", false);
        }
    }

    void UpdateSearchingState()
    {
        agent.speed = runSpeed;
        animator.SetBool("IsWalking", true);

        if (key == null)
        {
            key = GameObject.FindGameObjectWithTag("Key")?.transform;
            if (key == null) return;
        }

        agent.SetDestination(key.position);
        isAtKey = Vector3.Distance(transform.position, key.position) <= barkDetectionRadius;

        if (isAtKey)
        {
            currentState = DogState.BarkingAtKey;
            agent.ResetPath();
            animator.SetBool("IsWalking", false);
            TriggerBark();
        }
    }

    void UpdateBarkingAtKeyState()
    {
        agent.speed = 0;
        animator.SetBool("IsWalking", false);

        if (key != null)
        {
            FaceTarget(key.position);
        }
        else
        {
            currentState = DogState.Returning;
        }
    }

    void UpdateAnimations()
    {
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed / runSpeed);
    }

    void HandleBarking()
    {
        if (currentState == DogState.BarkingAtKey && Time.time >= nextBarkTime && !isBarking)
        {
            TriggerBark();
            SetNextBarkTime();
        }
    }

    void HandleCallSound()
    {
        if (shouldPlayCallSound && !isCallSoundPlaying)
        {
            PlayCallSound();
        }
        else if (!shouldPlayCallSound && isCallSoundPlaying)
        {
            StopCallSound();
        }
    }

    void PlayCallSound()
    {
        if (callSound == null) return;

        isCallSoundPlaying = true;
        callAudioSource.clip = callSound;
        callAudioSource.Play();
        Invoke("OnCallSoundFinished", callSound.length);
    }

    void StopCallSound()
    {
        isCallSoundPlaying = false;
        callAudioSource.Stop();
        CancelInvoke("OnCallSoundFinished");
    }

    void OnCallSoundFinished()
    {
        isCallSoundPlaying = false;
        if (shouldPlayCallSound)
        {
            PlayCallSound(); // Repeat if still in returning state
        }
    }

    void TriggerBark()
    {
        isBarking = true;
        animator.SetTrigger("Bark");
        if (barkSound != null)
        {
            AudioSource.PlayClipAtPoint(barkSound, transform.position, 1f);
        }
        Invoke("ResetBarking", 0.5f);
    }

    void ResetBarking()
    {
        isBarking = false;
    }

    void SetNextBarkTime()
    {
        nextBarkTime = Time.time + Random.Range(minBarkInterval, maxBarkInterval);
    }

    void FaceTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    public void ReturnToPlayer()
    {
        if (currentState == DogState.Returning) return;

        currentState = DogState.Returning;
        isAtKey = false;
        shouldPlayCallSound = true;
        Debug.Log("Command: Return to Player");
    }

    public void SearchForKey()
    {
        if (currentState == DogState.Searching || currentState == DogState.BarkingAtKey) return;

        currentState = DogState.Searching;
        isAtKey = false;
        shouldPlayCallSound = false;
        SetNextBarkTime();
        Debug.Log("Command: Search for Key");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0.5f, 1f, 0.2f);
        Gizmos.DrawWireSphere(transform.position, followDistance);

        if (currentState == DogState.Searching || currentState == DogState.BarkingAtKey)
        {
            Gizmos.color = new Color(1f, 0.92f, 0.16f, 0.3f);
            Gizmos.DrawWireSphere(transform.position, barkDetectionRadius);
        }
    }
}