using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Text timerText;
    float time;
    bool isRunning = true;

    void Update()
    {
        if (!isRunning) return;

        time += Time.deltaTime;
        int min = (int)(time / 60);
        int sec = (int)(time % 60);
        int ms = (int)((time * 1000) % 1000);
        timerText.text = $"{min:00}:{sec:00}:{ms:000}";
    }

    public void StopTimer() => isRunning = false;
}
