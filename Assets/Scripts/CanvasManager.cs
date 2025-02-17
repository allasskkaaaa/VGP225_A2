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
    [SerializeField] private List<Image> hearts;
    

    private void Start()
    {
        instance = this;
    }
    public void updateScoreUI()
    {
        if (scoreText != null) scoreText.text = GameManager.gameManager.score.ToString();
    }

    public void healthUI()
    {
        for(int i = 0; i < hearts.Count; i++) {
            if (i >= PlayerStateManager.Instance.playerHealth)
            {
                hearts[i].gameObject.SetActive(false);
            } else
            {
                hearts[i].gameObject.SetActive(true);
            }
        }
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

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
