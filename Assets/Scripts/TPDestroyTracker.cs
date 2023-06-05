using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TPDestroyTracker : MonoBehaviour
{
    public TPSpawnManager spawnManager;

    private void OnDestroy()
    {
        // Notify the spawn manager that the tpPrefab was destroyed
        if (spawnManager != null)
        {
            spawnManager.TPDestroyed();
        }
    }
}