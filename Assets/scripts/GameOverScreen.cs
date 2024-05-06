using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text scoreTxt;
    public TMP_Text highscoreText;

    public void Setup(int score, int highscore) {
        gameObject.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        scoreTxt.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    public void RestartBtn() {
        SceneManager.LoadScene("Game");
    }

    public void ExitBtn() {
        Application.Quit();
    }
}
