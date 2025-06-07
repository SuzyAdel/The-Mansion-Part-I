using UnityEngine;

public class OakTreeSpawner : MonoBehaviour
{
    public Transform treeParent; //New parent field, to easly hide in inspecctor 

    public GameObject oakTreePrefab;
    public Terrain terrain;
    public int numberOfTrees = 500;

    void Start()
    {
        if (oakTreePrefab == null)
        {
            Debug.LogError("oakTreePrefab is not assigned!");
            return;
        }
        if (terrain == null)
        {
            Debug.LogError("Terrain reference is missing!");
            return;
        }

        SpawnTrees();
    }

    void SpawnTrees()
    {
        TerrainData tData = terrain.terrainData;
        Vector3 terrainPos = terrain.transform.position;

        for (int i = 0; i < numberOfTrees; i++)
        {
            float randX = Random.Range(0, tData.size.x);
            float randZ = Random.Range(0, tData.size.z);
            float height = tData.GetInterpolatedHeight(randX / tData.size.x, randZ / tData.size.z);

            Vector3 spawnPos = new Vector3(
                terrainPos.x + randX,
                terrainPos.y + height,
                terrainPos.z + randZ
            );

            //Debug.Log($"Trying spawn #{i + 1} at {spawnPos}");

            GameObject tree = Instantiate(oakTreePrefab, spawnPos, Quaternion.identity);

            if (treeParent != null)
                tree.transform.parent = treeParent; // Parent assignment
        }
    

         Debug.Log($" Oak Trees Spawned: {numberOfTrees}");
    }
}
