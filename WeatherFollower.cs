using UnityEngine;

public class WeatherFollower : MonoBehaviour
{
    [Header("References")]
    public Transform player;           // Assign the player in Inspector
    //public Vector3 offset = new Vector3(0, 5, 0); // Elevate above player
    public Transform cameraTransform;    // Assign camera in Inspector

    [Header("Offset from Camera (in local space)")]
    public Vector3 offsetFromCamera = new Vector3(0f, 2.5f, 2f); // adjust as needed


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void LateUpdate()
    {
        if (player == null || cameraTransform == null)
            return;

        // Keep fog/rain following the player's position
        Vector3 targetPosition = player.position + cameraTransform.TransformDirection(offsetFromCamera);
        transform.position = targetPosition;

        // Match rotation with camera for immersive directionality
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    }
}
