using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody enemyRb;
    private GameObject turnPoint;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        turnPoint = GameObject.FindGameObjectWithTag("turnPoint");


        Vector3 lookDirection = (turnPoint.transform.position - transform.position).normalized;
        enemyRb.AddForce( lookDirection * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the tpPrefab
        if (other.CompareTag("turnPoint"))
        {
            // Destroy the tpPrefab
            Destroy(other.gameObject);

            // Turn right when colliding with the tpPrefab
            transform.Rotate(Vector3.up, 90f);
        }
    }
}
