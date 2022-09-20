using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string PlayerName;
    public string BestScorePlayer;
    public int BestScorePoints;
    private string saveFilePath = "/bestscore.json";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadBestScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    class MenuData
    {
        public string BestScorePlayer;
        public int BestScorePoints;

        public MenuData(string player, int points)
        {
            this.BestScorePlayer = player;
            this.BestScorePoints = points;
        }
    }

    public void SaveBestScore()
    {
        MenuData data = new MenuData(BestScorePlayer, BestScorePoints);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + saveFilePath, json);
    }
    
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + saveFilePath;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            MenuData data = JsonUtility.FromJson<MenuData>(json);
            BestScorePlayer = data.BestScorePlayer;
            BestScorePoints = data.BestScorePoints;
        } else
        {
            BestScorePlayer = "";
            BestScorePoints = 0;
        }
    }

}
