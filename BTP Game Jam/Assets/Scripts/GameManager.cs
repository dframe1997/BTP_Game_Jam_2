using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton pattern
    public static GameManager gameManager;

    //Variables
    public int score;
    int startSpeed = 4;
    public int speed = 4;
    public float speedAugment = 0;
    public bool gameOver = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    public Button restartButton;
    public Button quitButton;

    void Awake()
    {
        if (gameManager != null)
            GameObject.Destroy(gameManager);
        else
            gameManager = this;

        //DontDestroyOnLoad(this);       
    }

    void Start()
    {
        restartButton.onClick.AddListener(restartButtonClicked);
        quitButton.onClick.AddListener(quitButtonClicked);
        gameManager.speed = gameManager.startSpeed;
    }

    public void addScore(int addition)
    {
        Debug.Log("Score: " + gameManager.score + ", GameOver = " + gameManager.gameOver);
        if (!gameManager.gameOver)
        {
            gameManager.score += addition;
            gameManager.drawScore();
        }             
    }

    public void removeScore(int reduction)
    {
        if (!gameManager.gameOver)
        {
            gameManager.score -= reduction;
            gameManager.drawScore();
        }      
    }

    public void setScore(int newScore)
    {
        if (!gameManager.gameOver)
        {
            gameManager.score = newScore;
            gameManager.drawScore();
        }       
    }

    public void drawScore()
    {
        Debug.Log(scoreText);
        scoreText.SetText("Score: {0}", gameManager.score);
        gameOverScoreText.SetText("Score: {0}", gameManager.score);
    }

    /* ----- SPEED ----- */

    public void speedIncrease(int addition)
    {
        gameManager.speed += addition;
    }

    /* ----- RESTART ----- */

    public void restartButtonClicked()
    {
        gameManager.gameOver = false;
        gameManager.setScore(0);
        gameManager.speed = gameManager.startSpeed;
        gameManager.speedAugment = 0;
        SceneManager.LoadScene("Game");
    }

    public void quitButtonClicked()
    {
        Application.Quit();
    }
}
