using UnityEngine;
using System;

public class SelectionQuestion : MonoBehaviour
{
    public event Action<bool> OnSelectionComplete;

    public bool YesOrNo;
    public GameObject panel;

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
}
