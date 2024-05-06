using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_Text highscoreText;
    private int highscore;

    private void Start() {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    public void StartBtn() {
        SceneManager.LoadScene("Game");
    }
}
