// YouTube Tutorial Refrence: https://www.youtube.com/watch?v=8b1a9c4d2f0
// plus my tweaks 
using UnityEngine;

public class LightiningController : MonoBehaviour
{
    public GameObject LightingONE;
    public GameObject LightingTWO;
    public GameObject LightingTHREE;


    public GameObject AudioONE;
    public GameObject AudioTWO;


    private float timer = 0f;
    private float thunderInterval = 30f; // every 30 seconds +

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LightingONE.SetActive(false);
        LightingTWO.SetActive(false);
        LightingTHREE.SetActive(false);

        AudioONE.SetActive(false);
        AudioTWO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Timer-based lightning trigger
        timer += Time.deltaTime;
        if (timer >= thunderInterval)
        {
            timer = 0f;
            Invoke("CallLighting", Random.Range(0.5f, 1.5f)); // small delay before light starts (30 sec to 31.5)
        }
    }
    void CallLighting()
    {
        // randomly select one of the three lighting objects, each differnt duration 
        int r = Random.Range(1, 4); // Random number between 1 and 3
        float flashDuration = 0.0f;
        switch (r)
        {
            case 1:
                LightingONE.SetActive(true);
                //CallAudio();
                //Invoke("EndLighting", 0.125f); //Slowest
                flashDuration = 0.125f;
                break;
            case 2:
                LightingTWO.SetActive(true);
                //CallAudio();
                //Invoke("EndLighting", 0.105f);// Medium 
                flashDuration = 0.105f;
                break;
            case 3:
                LightingTHREE.SetActive(true);
                //CallAudio();
                //Invoke("EndLighting", 0.80f);// Quick
                flashDuration = 0.80f;

                break;
        }
        // Delay sound AFTER the flash starts
        Invoke("CallAudio", flashDuration + Random.Range(0.5f, 2.5f));

        // Turn off lights after brief flash
        Invoke("EndLighting", flashDuration);
    }

    void EndLighting()
    {
        // for simplicity set all with 0 
        LightingONE.SetActive(false);
        LightingTWO.SetActive(false);
        LightingTHREE.SetActive(false);
    }

    void CallAudio()
    {
        // randomly select one of the two audio objects
        int r = Random.Range(1, 3);
        switch (r)
        {
            case 1:
                AudioONE.SetActive(true);
                break;
            case 2:
                AudioTWO.SetActive(true);
                break;

                // Turn off after 0.5s
                Invoke("EndAudio", 0.5f);
        }

    }
        void EndAudio()
        {
            // for simplicity set both with 0 
            AudioONE.SetActive(false);
            AudioTWO.SetActive(false);
        }
    }

