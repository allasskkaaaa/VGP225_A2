using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        instance = this;
    }
    public void updateScoreUI()
    {
        if (scoreText != null) scoreText.text = GameManager.gameManager.score.ToString();
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in Editor
#else
            Application.Quit(); // Quits the built application
#endif
    }
}
