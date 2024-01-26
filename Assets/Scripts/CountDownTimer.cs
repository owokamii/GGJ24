using UnityEngine;
using TMPro;
using System;

public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float timeRemaining = 60;

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateCountdownText();
        }
        else
        {
            countdownText.text = "00:00";
            TimeLimit();
        }
    }

    void UpdateCountdownText()
    {
        TimeSpan time = TimeSpan.FromSeconds(timeRemaining);
        countdownText.text = time.ToString(@"mm\:ss");
    }

    private void TimeLimit()
    {
        if (timeRemaining == 0)
        {
            Time.timeScale = 0;
        }
    }
}
