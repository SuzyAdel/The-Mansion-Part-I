using UnityEngine;

public class RockProjectile : MonoBehaviour

{
    public AudioClip shatterSound;             
    private AudioSource audioSource;           
    private Animator animator; // Given animator on the rock


    private bool hasShattered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) // called when the rock collides with another object
     
    {
        if (hasShattered) return;  // Avoid double triggering, happens when the rock hits multiple objects
        hasShattered = true;

        // Play shatter animation
        if (animator != null)
            animator.SetTrigger("Shatter");

        // Play shatter sound
        if (audioSource != null && shatterSound != null)
            audioSource.PlayOneShot(shatterSound);

        // Optional: disable collider to prevent further hits
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        // Destroy after 1 second to allow animation and sound to play
        Destroy(gameObject, 1f);
    }

// Update is called once per frame
void Update()
    {
        
    }
}
