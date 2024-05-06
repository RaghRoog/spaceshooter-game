using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public Text highscoreText;

    public static GameController instance;
    
    public int score = 0;
    public int lives = 3;
    private int highscore = 0;
    private bool isGameOver = false;

    public GameOverScreen gameOverScreen;

    private void Awake() {
        instance = this;
        Time.timeScale = 1.0f;
    }

    private void Start() {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    private void Update() {
        if(lives <= 0) {
            isGameOver = true;
            GameOver();
        }
    }

    public void AddPoints(int points) {
        score += points;
        scoreText.text = "Score: " + score.ToString();
        if (highscore < score) {
            PlayerPrefs.SetInt("highscore", score);
            highscore = score;
            highscoreText.text = "Highscore: " + highscore.ToString();
        }
    }

    public void SubtractLives(int lives) {
        this.lives -= lives;
        livesText.text = "Lives: " + this.lives.ToString();
    }

    private void GameOver() {
        gameOverScreen.Setup(score, highscore);
    }

    public bool IsGameOver() {
        return isGameOver;
    }
}
