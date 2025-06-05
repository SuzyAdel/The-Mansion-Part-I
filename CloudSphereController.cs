using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CloudSphereController : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeedY = 10f; // Medium speed

    [Header("Gloom Settings")]
    public bool gloomyMode = true;
    public Color gloomyColor = new Color(0.5f, 0.5f, 0.5f, 0.7f);

    private Material cloudMaterial;
    private float currentRotation = 0f;

    void Start()
    {
        // Get the cloud sphere material
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            cloudMaterial = renderer.material;

            if (gloomyMode && cloudMaterial.HasProperty("_Color"))
            {
                cloudMaterial.color = gloomyColor;
            }
        }
    }

    void Update()
    {
        // Rotate the GameObject around Y-axis
        transform.Rotate(Vector3.up * rotationSpeedY * Time.deltaTime);

        // Optional: rotate shader texture if supported
        if (cloudMaterial != null && cloudMaterial.HasProperty("_Rotation"))
        {
            currentRotation += rotationSpeedY * Time.deltaTime;
            cloudMaterial.SetFloat("_Rotation", currentRotation);
        }

        // Optional: scroll texture if shader supports it
        if (cloudMaterial != null && cloudMaterial.HasProperty("_MainTex"))
        {
            Vector2 offset = new Vector2(Time.time * 0.005f, 0);
            cloudMaterial.mainTextureOffset = offset;
        }
    }
}
