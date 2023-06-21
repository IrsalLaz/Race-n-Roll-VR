using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float prepareTime;
    private Rigidbody enemyRb;
    private Animator enemyAnimate;
    bool isGameStart = false;
    GameManager gameManager;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public Transform turnPoint;
    Vector3 lookDirection;
    int currentPos = 3;
    bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        //set gameManager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        enemyRb = GetComponent<Rigidbody>();
        enemyAnimate = GetComponent<Animator>();
        
        //delay for preparation time
        Invoke(nameof(StartGame), prepareTime);

        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart && isGameActive)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        // animate take, then jump and go
        
        lookDirection = (turnPoint.position - transform.position).normalized;
        
        enemyRb.AddForce(lookDirection * speed);

        // animate jumping
        Jump();
        isGameStart = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect finish line and set game over for player
        if (other.CompareTag("FinishLine"))
        {
            Debug.Log("Bot finish Game over");
            gameManager.GameOver();

            isGameActive = false;
        }

        // Check if the collided object is the tpPrefab
        if (other.CompareTag("turnPoint"))
        {
            // Turn right when colliding with the tpPrefab
            transform.Rotate(Vector3.up, 90f);
        }

        //update position when collide with detector
        if (other.gameObject.CompareTag("PosDetector"))
        {
            Debug.Log("Position change");

            gameManager.UpdatePos(1);
        }
    }

    private void Jump()
    {
        //jump
        enemyAnimate.SetTrigger("Jump");

        //midair
        enemyAnimate.SetBool("Grounded", false);
    }

    public void SetTurnPoint(Transform turnPoint)
    {
        this.turnPoint = turnPoint;
    }
}
