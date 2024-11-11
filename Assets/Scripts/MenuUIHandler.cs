using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Für das alte Text-System

public class MenuUIHandler : MonoBehaviour
{
    public InputField nameInputField; // Referenz zum Eingabefeld für den Spielernamen
    public Text highScoreText; // Referenz zum Textfeld für den Highscore

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance != null)
        {
            Debug.Log("High Score Player Name: " + DataManager.Instance.highScorePlayerName);
            Debug.Log("High Score: " + DataManager.Instance.highScore);

            if (highScoreText != null)
            {
                if (!string.IsNullOrEmpty(DataManager.Instance.highScorePlayerName))
                {
                    highScoreText.text = "Highscore: " + DataManager.Instance.highScorePlayerName + " : " + DataManager.Instance.highScore;
                    Debug.Log("High Score Text wurde aktualisiert.");
                }
                else
                {
                    highScoreText.text = "High Score: 0";
                    Debug.Log("Kein Highscore vorhanden. Standard-Text wird gesetzt.");
                }
            }
            else
            {
                Debug.LogError("highScoreText ist null! Überprüfe die Zuweisung im Inspector.");
            }
        }
        else
        {
            Debug.LogError("DataManager.Instance ist null!");
        }
    }

    // Funktion, um das Spiel zu starten
    public void StartGame()
    {
        // Speichere den Namen des Spielers im DataManager
        DataManager.Instance.playerName = nameInputField.text;

        // Wechsle zur Spielszene
        SceneManager.LoadScene(1);
    }
   
    // Funktion, um das Spiel zu beenden

    public void ExitGame()
    {
#if UNITY_EDITOR
        // Im Editor beende den Play Mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Im Build beende das Spiel
            Application.Quit();
#endif
    }
}
