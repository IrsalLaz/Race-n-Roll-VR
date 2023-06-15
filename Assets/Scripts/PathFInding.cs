using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFInding : MonoBehaviour
{
    public Transform[] turnPoints;
    int turnPointIndex = 0;
    EnemyMovement enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        enemy.SetTurnPoint(turnPoints[turnPointIndex]);
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 targetPosition = turnPoints[turnPointIndex].position;

        Debug.Log(targetPosition + "=" + enemy.transform.position);

        float distanceThreshold = 0.1f;

        if (Vector3.Distance(enemy.transform.position, targetPosition) <= distanceThreshold)
        {
            turnPointIndex++;

            if (turnPointIndex < turnPoints.Length)
            {
                enemy.SetTurnPoint(turnPoints[turnPointIndex]);
                transform.Rotate(Vector3.up, 90f);
            }
        }
    }
}
