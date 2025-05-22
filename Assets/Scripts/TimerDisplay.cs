using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Text timerText;
    private float time;
    private bool isRunning = true;

    void Update()
    {
        if (!isRunning) return;

        time += Time.deltaTime;
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int milliseconds = (int)((time * 1000) % 1000);
        timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:000}";
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetTime()
    {
        return time;
    }
}