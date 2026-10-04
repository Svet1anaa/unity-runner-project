using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;
    string scoreLabelBase;

    void Start()
    {
        scoreLabelBase = highScoreText.text;
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = scoreLabelBase + " " + highScore;
    }

    public void StartGame() => SceneManager.LoadScene("Game"); // имя твоей игровой сцены
    public void ExitGame() => Application.Quit();
}
