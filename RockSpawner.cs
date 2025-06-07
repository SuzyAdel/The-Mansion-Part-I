using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public Transform rockParent; // to hide easier in inspector 

    public Terrain terrain;
    public GameObject[] rockPrefabs; // Assign all 3 in Inspector
    public int numberOfRocks = 150;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRocks();
    }

    void SpawnRocks()
    {
        TerrainData terrainData = terrain.terrainData;
        Vector3 terrainPos = terrain.transform.position;

        int rocksSpawned = 0;

        for (int i = 0; i < numberOfRocks * 5 && rocksSpawned < numberOfRocks; i++) // Try up to 5x attempts
        {
            float randX = Random.Range(0f, terrainData.size.x);
            float randZ = Random.Range(0f, terrainData.size.z);
            float normX = randX / terrainData.size.x;
            float normZ = randZ / terrainData.size.z;

            float height = terrainData.GetInterpolatedHeight(normX, normZ);
            Vector3 normal = terrainData.GetInterpolatedNormal(normX, normZ);

            if (Vector3.Angle(normal, Vector3.up) > 60f) continue; // Too steep

            Vector3 position = new Vector3(terrainPos.x + randX, terrainPos.y + height, terrainPos.z + randZ);
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal); // Align with terrain slope

            GameObject rock = Instantiate(
                rockPrefabs[Random.Range(0, rockPrefabs.Length)],
                position,
                rotation,
                rockParent //Parent assignment
            );

            rock.transform.up = normal; // Extra alignment just in case
            rock.name = $"Rock_{rocksSpawned}";
            rocksSpawned++;
        }


        Debug.Log($"[RockSpawner] Spawned {rocksSpawned} rocks.");
    }

// Update is called once per frame
void Update()
    {
        
    }
}
