using UnityEngine;

public class RockThrower : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject rockPrefab;
    public Transform throwOrigin; // hand
    public float throwForce = 100f;

    [Header("Inventory")]
    public int currentRocks = 10;
    public int maxRocks = 50;
    public float pickupRange = 3f;
    public LayerMask pickupLayerMask; // Assign in Inspector to only hit "RockPickup" layer

    [Header("References")]
    public Camera playerCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Left Click = Throw Rock
        if (Input.GetMouseButtonDown(0) && currentRocks > 0)
        {
            ThrowRock();
        }

        // Right Click = Pick Up Rock 
        if (Input.GetMouseButtonDown(1))
        {
            TryPickupRock();
        }
    }

    void ThrowRock()
    {
        GameObject rock = Instantiate(rockPrefab, throwOrigin.position, Quaternion.identity);

        if (rock.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.linearVelocity = playerCamera.transform.forward * throwForce;// apply throw force on the directio n the camera is facing
        }

        currentRocks--;
    }

    void TryPickupRock()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // center of screen
        if (Physics.Raycast(ray, out RaycastHit hit, pickupRange, pickupLayerMask))
        {
            if (hit.collider.CompareTag("Rock")) // use a consistent tag for all world rocks
            {
                if (currentRocks < maxRocks)
                {
                    Destroy(hit.collider.gameObject); // remove rock from world
                    currentRocks++;
                    Debug.Log($"[Rock Pickup] Picked up rock. Current: {currentRocks}");
                }
                else
                {
                    Debug.Log("[Rock Pickup] Inventory full!");
                }
            }
        }
    }
}
