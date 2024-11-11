using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Singleton-Instanz
    public static DataManager Instance;

    // Zu speichernde Daten
    public string playerName;
    public int highScore;
    public string highScorePlayerName;

    private void Awake()
    {
        // Singleton-Setup: Überprüfe, ob bereits eine Instanz existiert
        if (Instance != null)
        {
            Destroy(gameObject); // Zerstöre dieses Objekt, falls es eine weitere Instanz gibt
            return;
        }

        Instance = this; // Weise diese Instanz zu
        DontDestroyOnLoad(gameObject); // Verhindere, dass das Objekt beim Szenenwechsel zerstört wird

        LoadHighScore(); // Lade den Highscore beim Start
    }

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScorePlayerName = highScorePlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.highScorePlayerName;
            highScore = data.highScore;
        }
    }
}
