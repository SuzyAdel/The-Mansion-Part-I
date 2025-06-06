// YouTube Tutorial Refrence: https://www.youtube.com/watch?v=8b1a9c4d2f0
// plus my tweaks , flickering , 2 audios ,
// directional light detials , timmer, sound delay , soft fade out   
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
            case 1: // Slowest flicker - 8 flashes
                for (int i = 0; i < 8; i++)
                {
                    lightObject.SetActive(true);
                    yield return new WaitForSeconds(0.07f);
                    lightObject.SetActive(false);
                    yield return new WaitForSeconds(0.05f);
                }
                break;

            case 2: // Medium flicker - 6 flashes
                for (int i = 0; i < 6; i++)
                {
                    lightObject.SetActive(true);
                    yield return new WaitForSeconds(0.05f);
                    lightObject.SetActive(false);
                    yield return new WaitForSeconds(0.04f);
                }
                break;

            case 3: // Quick burst - 3 flashes
                for (int i = 0; i < 3; i++)
                {
                    lightObject.SetActive(true);
                    yield return new WaitForSeconds(0.04f);
                    lightObject.SetActive(false);
                    yield return new WaitForSeconds(0.03f);
                }
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
        StartCoroutine(FadeOut(AudioONE, 0.3f));
    }

    void EndAudioTWO()
    {
        StartCoroutine(FadeOut(AudioTWO, 0.3f));
    }

    IEnumerator FadeOut(GameObject audioObject, float fadeDuration)
    {
        AudioSource source = audioObject.GetComponent<AudioSource>();
        if (source == null)
        {
            audioObject.SetActive(false);
            yield break;
        }

        float startVolume = source.volume;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, 0f, time / fadeDuration);
            yield return null;
        }

        source.Stop();
        source.volume = startVolume;
        audioObject.SetActive(false);
    }

    // Legacy instant-off method (commented out for fade transition)
    // void EndAudioONE() { AudioONE.SetActive(false); }
    // void EndAudioTWO() { AudioTWO.SetActive(false); }
}
