using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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
        if (!endings.ContainsKey(endingKey) || !endings[endingKey])
        {
            endings[endingKey] = true;
            SaveData();

            //Collection collectionScript = FindObjectOfType<Collection>();
            //if (collectionScript != null)
            //{
            //    collectionScript.UpdateCollectionDisplay();
            //}
            //else
            //{
            //    Debug.LogError("Collection script not found in the scene.");
            //}
        }
    }

    public void RegisterButton(string buttonName, Button button)
    {
        switch (buttonName)
        {
            case "Yes":
                button.onClick.AddListener(selectionQuestion.Yes);
                break;
            case "No":
                button.onClick.AddListener(selectionQuestion.No);
                break;
            case "Retry":
                button.onClick.AddListener(selectionQuestion.Retry);
                break;
            case "Menu":
                button.onClick.AddListener(selectionQuestion.Menu);
                break;
        }
    }

    internal static void RegisterButton(string name, ButtonControl buttonControl)
    {
        throw new NotImplementedException();
    }

    public void PrintEndings()
    {
        foreach (var ending in endings)
        {
            Debug.Log($"Ending: {ending.Key}, Unlocked: {ending.Value}");
        }
    }

    public void ResetGame()
    {
        foreach (HoldingItem item in FindObjectsOfType<HoldingItem>())
        {
            item.ResetInteraction();
        }
    }

    public void ResetData()
    {
        var keys = new List<string>(endings.Keys);
        foreach (var key in keys)
        {
            endings[key] = false;
        }

        SaveData();
    }
}
