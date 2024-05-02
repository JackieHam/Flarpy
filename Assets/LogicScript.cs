using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource scoreSFX;
    public AudioSource deathSFX;
    public CircleCollider2D birdCollider;
    private bool isGameOver = false;

    /* will be used in other scripts, therefore use "public void"
     * add 1 to playerscore
     */

     void Start()
    {
        birdCollider = GameObject.FindGameObjectWithTag("Bird").GetComponent<CircleCollider2D>();
        birdCollider.enabled = true;
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        scoreSFX.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void tryGameOver()
    {
        if (isGameOver) {
            return;
        }
        gameOverScreen.SetActive(true);
        deathSFX.Play();
        deActivateCollider();
        isGameOver = true;
    }


    void deActivateCollider() {
        birdCollider.enabled = false;
    }
}
