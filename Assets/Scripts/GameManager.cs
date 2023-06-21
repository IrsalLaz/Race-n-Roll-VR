using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finishOverText;
    public TextMeshProUGUI positionText;
    public Button restartButton;
    int currentPos = 1;
    int lastPos = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        positionText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePos(int enemyPos)
    {
        //change position text
        if(positionText.text == "1/3")
        {
            currentPos += enemyPos;
            positionText.text = currentPos + "/" + lastPos;

        }
        else if (positionText.text == "2/3")
        {
            currentPos += enemyPos;
            positionText.text = currentPos + "/" + lastPos;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //update pos when pass the enemy
        if(other.gameObject.CompareTag("Enemy")) {
            UpdatePos(-1);
        }

        if (other.gameObject.CompareTag("Finish")) {
            finishOverText.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
