using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        }
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
}
