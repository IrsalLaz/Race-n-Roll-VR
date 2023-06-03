using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSpawnManager : MonoBehaviour
{
    public GameObject tpPrefab;
    private int tpCount = 0;
    private int waveNumber = 0;

    private List<Vector3> spawnPositions;
    private int currentSpawnIndex;

    void Start()
    {
        // Initialize the list of spawn positions
        spawnPositions = new List<Vector3>
        {
            new Vector3(26f, 0f, 90f),
            new Vector3(88f, 0f, 90f),
            new Vector3(80f, 0f, 26f),
            new Vector3(24f, 0f, 26f),
            new Vector3(26f, 0f, 38.5f)
        };

        SpawnTPPrefab();
    }

    void Update()
    {
        if (tpCount == 0)
        {
            waveNumber++;
            SpawnTPPrefab();
        }
    }

    private void SpawnTPPrefab()
    {
        // Check if there are any available spawn positions
        if (currentSpawnIndex >= spawnPositions.Count)
        {
            Debug.Log("Enemy Finish, No more spawn positions available");
            return;
        }

        // Get the current spawn position and increment the index
        Vector3 spawnPos = spawnPositions[currentSpawnIndex];
        currentSpawnIndex++;

        // Spawn the tpPrefab at the current spawn position
        GameObject newTP = Instantiate(tpPrefab, spawnPos, tpPrefab.transform.rotation);
        tpCount++;

        // Attach a script to the tpPrefab to track its destruction
        TPDestroyTracker destroyTracker = newTP.AddComponent<TPDestroyTracker>();
        destroyTracker.spawnManager = this;
    }

    public void TPDestroyed()
    {
        tpCount--;

        if (tpCount <= 0)
        {
            // All tpPrefabs have been destroyed, start a new wave or take appropriate action
            waveNumber++;
            SpawnTPPrefab();
        }
    }
}
