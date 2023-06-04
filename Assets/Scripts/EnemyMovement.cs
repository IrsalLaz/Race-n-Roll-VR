using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody enemyRb;
    private GameObject turnPoint;
    private Animator enemyAnimate;
    private bool isJumping = false;
    private float jumpTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyAnimate = GetComponent<Animator>();
        jumpTimer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        // animate take, then jump and go
        turnPoint = GameObject.FindGameObjectWithTag("turnPoint");
        Vector3 lookDirection = (turnPoint.transform.position - transform.position).normalized;
        enemyRb.AddForce( lookDirection * speed);

        // animate jumping    
        Jump();
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

    private void Jump()
    {
        enemyAnimate.SetTrigger("Jump");
        enemyAnimate.SetBool("Grounded", false);
    }
}
