using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance { get; private set; }

    public string playerName;
    public string nameOfPlayerWithBestScore = "";
    public int highestScore = 0;

    string saveFilePath;

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "playerdata.json");

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        PlayerData savedData = LoadGameData();
        if (savedData != null)
        {
            nameOfPlayerWithBestScore = savedData.name;
            highestScore = savedData.score;
        }
    }

    

    public void SetHighestScore(int score)
    {
        if (score > highestScore)
        {
            nameOfPlayerWithBestScore = playerName;
            highestScore = score;
        }
        
    }

    public string CreateHighestScoreText()
    {
        return "Best Score : " + nameOfPlayerWithBestScore + " : " + highestScore;
    }

    [Serializable]
    public class PlayerData
    {
        public string name;
        public int score;

        public PlayerData(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public void SaveGameDate(PlayerData date)
    {
        string json = JsonUtility.ToJson(date, true);
        File.WriteAllText(saveFilePath, json);
    }
    
    public PlayerData LoadGameData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }else
        {
            Debug.LogWarning("save file not found");
            return null;
        }
    }

    void OnApplicationQuit()
    {
        PlayerData currentData = new PlayerData(nameOfPlayerWithBestScore, highestScore);
        SaveGameDate(currentData);
    }
}
