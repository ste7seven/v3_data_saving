using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
