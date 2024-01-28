using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SelectionQuestion : MonoBehaviour
{
    public event Action<bool> OnSelectionComplete;

    public bool YesOrNo;
    public GameObject panel;
    public  CountDownTimer timer;
    public CalculateEnding endingScript;

    public void Start()
    {
        timer = FindObjectOfType<CountDownTimer>();
        if (timer == null)
        {
            Debug.LogError("CountDownTimer not found in the scene.");
        }

        endingScript = FindObjectOfType<CalculateEnding>();
        if (timer == null)
        {
            Debug.LogError("CalculateEnding not found in the scene.");
        }
    }
    public void No()
    {
        YesOrNo = false;
        panel.SetActive(false);
        Time.timeScale = 1.0f;
        Debug.Log("was no call");
        OnSelectionComplete?.Invoke(YesOrNo);
    }

    public void Yes()
    {
        YesOrNo = true;
        panel.SetActive(false);
        Time.timeScale = 1.0f;
        Debug.Log("was call");
        OnSelectionComplete?.Invoke(YesOrNo);
    }

    public void Retry()
    {
        timer.isTimeLimit = false; 
        endingScript.wasEnding = false;
        Time.timeScale = 1.0f;
        Debug.Log("WasClickRetry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        timer.isTimeLimit = false;
        Time.timeScale = 1.0f;
        endingScript.wasEnding = false;
        SceneManager.LoadScene("TitleScreen");
    }
}
