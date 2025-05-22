using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompletionScreen : MonoBehaviour
{
    public GameObject completionPanel;
    public Image[] stars;
    public Text timeText;
    public TimerDisplay timer;
    public Button playAgainButton; // 👈 Add this in Inspector

    void Start()
    {
        // Hook up the button at runtime
        playAgainButton.onClick.AddListener(RestartGame);
    }

    public void ShowCompletion(float finalTime)
    {
        completionPanel.SetActive(true);

        int minutes = (int)(finalTime / 60);
        int seconds = (int)(finalTime % 60);
        int milliseconds = (int)((finalTime * 1000) % 1000);
        timeText.text = $"Time: {minutes:00}:{seconds:00}:{milliseconds:000}";

        int starCount = 1;
        if (finalTime <= 45f) starCount = 3;
        else if (finalTime <= 70f) starCount = 2;

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = i < starCount;
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
