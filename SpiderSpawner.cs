﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class SpiderSpawner : MonoBehaviour
{
    // put both to pick from 
    [Header("Prefabs")]
    [SerializeField] private GameObject blackSpiderPrefab;
    [SerializeField] private GameObject brownSpiderPrefab;

    [Header("Spawn Settings")]
    public int totalSpiders = 80; // total number of spiders to spawn, set in instructions 
    public float minDistanceFromMansion = 50f; // minimum distance from the mansion to spawn spiders
    public float minDistanceBetweenSpiders = 15f; // new: ensure spiders are not clustered
    private Terrain terrain;
    private Vector3 mansionPosition = new Vector3(382, 242, 727); // position of the mansion, set in instructions
    private List<Vector3> usedSpawnPoints = new List<Vector3>(); // store positions to ensure spread

    void Start()
    {
        terrain = Terrain.activeTerrain;
        if (terrain == null)
        {
            Debug.LogError("No active terrain found!");
            return;
        }
        if (blackSpiderPrefab == null || brownSpiderPrefab == null)
        {
            Debug.LogError("Spider prefabs not assigned!");
            return;
        }
        SpawnSpiders();
    }

    void SpawnSpiders()
    {
        int spawnedCount = 0;
        int attempts = 0;
        int maxAttempts = totalSpiders * 20; // increase attempts to improve random distribution

        while (spawnedCount < totalSpiders && attempts < maxAttempts)
        {
            Vector3 spawnPos = GetValidSpawnPosition();
            attempts++;

            if (spawnPos == Vector3.zero) continue;

            // ensure the new position is far enough from all previous spiders
            bool tooClose = false;
            foreach (Vector3 existing in usedSpawnPoints)
            {
                if (Vector3.Distance(existing, spawnPos) < minDistanceBetweenSpiders)
                {
                    tooClose = true;
                    break;
                }
            }
            if (tooClose) continue;

            usedSpawnPoints.Add(spawnPos);

            GameObject prefab = Random.value > 0.5f ? blackSpiderPrefab : brownSpiderPrefab;
            GameObject spiderGO = Instantiate(prefab, spawnPos, Quaternion.identity, transform);

            // Assign player reference
            SpiderController spiderController = spiderGO.GetComponent<SpiderController>();
            if (spiderController != null)
            {
                GameObject detectiveObj = GameObject.FindGameObjectWithTag("Player");
                if (detectiveObj != null)
                {
                    spiderController.player = detectiveObj.transform;
                }
                else
                {
                    Debug.LogError("[SpiderSpawner] No GameObject tagged 'Player' found!");
                }
            }

            // Validate other components
            ValidateSpiderComponents(spiderGO);
            spawnedCount++;
        }

        // Optional: Summary debug log
        Debug.Log($"[SpiderSpawner] Spawned {spawnedCount} spiders successfully.");
    }

    void ValidateSpiderComponents(GameObject spider)
    {
        var controller = spider.GetComponent<SpiderController>();
        var agent = spider.GetComponent<NavMeshAgent>();
        var animator = spider.GetComponent<Animator>();

        if (controller == null)
            Debug.LogError("Missing SpiderController!", spider);
        if (agent == null)
            Debug.LogError("Missing NavMeshAgent!", spider);
        if (animator == null || animator.runtimeAnimatorController == null)
            Debug.LogError("Animator missing or no controller assigned!", spider);
    }

    Vector3 GetValidSpawnPosition()
    {
        Vector3 terrainSize = terrain.terrainData.size;
        Vector3 terrainPos = terrain.transform.position;

        for (int i = 0; i < 15; i++) // increased number of attempts per call
        {
            Vector3 pos = new Vector3(
                Random.Range(terrainPos.x, terrainPos.x + terrainSize.x),
                0,
                Random.Range(terrainPos.z, terrainPos.z + terrainSize.z)
            ); // random position within the terrain bounds
            pos.y = terrain.SampleHeight(pos) + terrainPos.y;

            Vector2 norm = new Vector2(
                (pos.x - terrainPos.x) / terrainSize.x,
                (pos.z - terrainPos.z) / terrainSize.z);
            float slope = Vector3.Angle(
                terrain.terrainData.GetInterpolatedNormal(norm.x, norm.y),
                Vector3.up); // get the slope of the terrain at the position

            if (slope <= 60f && Vector3.Distance(pos, mansionPosition) >= minDistanceFromMansion)
                return pos; // valid position found
        }

        return Vector3.zero; // return zero if no valid position found
    }
}
