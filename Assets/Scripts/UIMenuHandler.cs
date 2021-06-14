using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class UIMenuHandler : MonoBehaviour
{
    
    [SerializeField] private Text nameField;
    [SerializeField] private Text bestScoreText;
    public void Awake()
    {
        bestScoreText.text = "Best Score: " + SaveManager.Instance.BestScoreName + ": " + SaveManager.Instance.BestScore;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        SaveManager.Instance.CurrentName = nameField.text;

    }

    public void ExitGame()
    {
        //MainManager.Instance.SaveData();
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
            SaveManager.Instance.SaveBestScore();
        }

        else
        {
            Application.Quit(); // original code to quit Unity player
            SaveManager.Instance.SaveBestScore();
        }

    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
