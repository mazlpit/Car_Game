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

        int hours = (int)(time / 3600);
        int minutes = (int)((time % 3600) / 60);
        int seconds = (int)(time % 60);

        timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
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
