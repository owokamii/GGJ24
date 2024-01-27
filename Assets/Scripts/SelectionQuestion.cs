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
        OnSelectionComplete?.Invoke(YesOrNo);
    }

    public void Yes()
    {
        YesOrNo = true;
        panel.SetActive(false);
        Time.timeScale = 1.0f;
        OnSelectionComplete?.Invoke(YesOrNo);
    }
}
