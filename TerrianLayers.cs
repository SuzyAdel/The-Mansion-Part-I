using UnityEngine;

public class TerrainLayers : MonoBehaviour
{
    [Header("Assign your terrain layers here")]
    public TerrainLayer[] terrainLayers;

    [Header("Blend Settings")]
    public float blendScale = 20f;

    private Terrain terrain;
    private TerrainData terrainData;

    void Start()
    {
        terrain = GetComponent<Terrain>();
        terrainData = terrain.terrainData;

        if (terrainLayers.Length < 2)
        {
            Debug.LogError("Please assign at least two terrain layers.");
            return;
        }

        ApplyTerrainLayers();
        GenerateBlendMap();
    }

    void ApplyTerrainLayers()
    {
        terrainData.terrainLayers = terrainLayers;
    }

    void GenerateBlendMap()
    {
        int width = terrainData.alphamapWidth;
        int height = terrainData.alphamapHeight;
        int numLayers = terrainLayers.Length;

        float[,,] map = new float[width, height, numLayers];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float normX = x / (float)width;
                float normY = y / (float)height;

                float blend = Mathf.PerlinNoise(normX * blendScale, normY * blendScale);

                // Assume 2 layers for simplicity (extend logic for more)
                map[x, y, 0] = blend;
                map[x, y, 1] = 1f - blend;
            }
        }

        terrainData.SetAlphamaps(0, 0, map);
        Debug.Log("Terrain layers blended successfully.");
    }
}