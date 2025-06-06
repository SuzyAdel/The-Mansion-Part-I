// YouTube Tutorial Refrence: https://www.youtube.com/watch?v=8b1a9c4d2f0
// plus my tweaks , flickering , 2 audios , directional light detials , timmer, sound delay  
using UnityEngine;
using System.Collections;

public class LightiningController : MonoBehaviour
{
    public GameObject LightingONE;
    public GameObject LightingTWO;
    public GameObject LightingTHREE;

    public GameObject AudioONE;
    public GameObject AudioTWO;

    private float timer = 0f;
    private float thunderInterval = 10f; // every 10 seconds - higjj frequency thunder

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LightingONE.SetActive(false);
        LightingTWO.SetActive(false);
        LightingTHREE.SetActive(false);

        AudioONE.SetActive(false);
        AudioTWO.SetActive(false);

        // Immediately trigger first lightning when game starts
        Invoke("CallLighting", 1f);
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
        GameObject selectedLighting = null;

        switch (r)
        {
            case 1:
                selectedLighting = LightingONE;
                break;
            case 2:
                selectedLighting = LightingTWO;
                break;
            case 3:
                selectedLighting = LightingTHREE;
                break;
        }

        StartCoroutine(FlashLightning(selectedLighting, r));
    }

    IEnumerator FlashLightning(GameObject lightObject, int type)
    {
        // Flickering effect based on lightning type
        switch (type)
        {
            case 1: // Slowest flicker
                lightObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                lightObject.SetActive(false);
                yield return new WaitForSeconds(0.05f);
                lightObject.SetActive(true);
                yield return new WaitForSeconds(0.15f);
                break;

            case 2: // Medium flicker
                lightObject.SetActive(true);
                yield return new WaitForSeconds(0.08f);
                lightObject.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                lightObject.SetActive(true);
                yield return new WaitForSeconds(0.07f);
                break;

            case 3: // Quick burst
                lightObject.SetActive(true);
                yield return new WaitForSeconds(0.06f);
                break;
        }

        // Turn off all lighting objects to ensure clean reset
        LightingONE.SetActive(false);
        LightingTWO.SetActive(false);
        LightingTHREE.SetActive(false);

        // Shorter and more realistic delay between lightning and thunder
        float delayAfterFlash = Random.Range(0.1f, 0.3f);
        Invoke("CallAudio", delayAfterFlash);
    }

    void CallAudio()
    {
        // randomly select one of the two audio objects
        int r = Random.Range(1, 3);
        switch (r)
        {
            case 1:
                AudioONE.SetActive(true);
                Invoke("EndAudioONE", 2.1f); // Turn off after 0.9s
                break;
            case 2:
                AudioTWO.SetActive(true);
                Invoke("EndAudioTWO", 2.3f); // Turn off after 1s
                break;
        }
    }

    void EndAudioONE()
    {
        AudioONE.SetActive(false);
    }

    void EndAudioTWO()
    { 
        AudioTWO.SetActive(false);
    }
}
