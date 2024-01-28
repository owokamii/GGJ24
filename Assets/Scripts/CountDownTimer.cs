using UnityEngine;
using TMPro;
using System;

public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float timeRemaining = 60;
    public bool isTimeLimit = false;

    public void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateCountdownText();
        }
        else if (!isTimeLimit)
        {
            countdownText.text = "00:00";
            TimeLimit();
        }
    }

    void UpdateCountdownText()
    {
        TimeSpan time = TimeSpan.FromSeconds(Math.Max(0, timeRemaining));
        countdownText.text = time.ToString(@"mm\:ss");
    }

    private void TimeLimit()
    {
        Time.timeScale = 0;
        isTimeLimit = true;
        Debug.Log("Time limit reached");
    }

}
