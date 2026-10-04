using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text finalScoreText;
    string scoreLabelBase;

    void Awake()
    {
        Instance = this;
        scoreLabelBase = finalScoreText.text; // запоминаем "Overall:" при старте игры
    }

    public void GameOver(int coinsCollected)
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (coinsCollected > highScore)
            PlayerPrefs.SetInt("HighScore", coinsCollected);

        finalScoreText.text = scoreLabelBase + " " + coinsCollected;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
