using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private SelectionQuestion selectionQuestion;
    public Dictionary<string, bool> endings = new Dictionary<string, bool>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        selectionQuestion = GetComponent<SelectionQuestion>();
    }

    public void SaveData()
    {
        foreach (var ending in endings)
        {
            PlayerPrefs.SetInt(ending.Key, ending.Value ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        for (int i = 1; i <= 6; i++)
        {
            string key = "Ending" + i;
            endings[key] = PlayerPrefs.GetInt(key, 0) == 1;
        }
    }

    public void UnlockEnding(string endingKey)
    {
        if (!endings.ContainsKey(endingKey))
        {
            endings[endingKey] = true;
            SaveData();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (selectionQuestion == null)
        {
            Debug.LogError("SelectionQuestion reference is lost or not set.");
            return;
        }

        Button Yes = GameObject.Find("Yes").GetComponent<Button>();
        Button No = GameObject.Find("No").GetComponent<Button>();
        Button Retry = GameObject.Find("Retry").GetComponent<Button>();
        Button Menu = GameObject.Find("Menu").GetComponent<Button>();

        if (Yes != null && No != null && Retry != null && Menu != null)
        {
            Debug.Log("u was reset all");
            Yes.onClick.RemoveAllListeners();
            Yes.onClick.AddListener(selectionQuestion.Yes);

            No.onClick.RemoveAllListeners();
            No.onClick.AddListener(selectionQuestion.No);

            Retry.onClick.RemoveAllListeners();
            Retry.onClick.AddListener(selectionQuestion.Retry);

            Menu.onClick.RemoveAllListeners();
            Menu.onClick.AddListener(selectionQuestion.Menu);
        }
        else
        {
            Debug.LogError("One or more buttons are not found in the current scene.");
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
