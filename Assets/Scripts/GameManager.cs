using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    [SerializeField] public int score;
    [SerializeField] public int scoreToWin;

    private void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            // Destroy duplicate instances of the gameManager
            Destroy(gameObject); 
            return;
        }

        gameManager = this;

        // Do not destroy gameManager across scenes
        DontDestroyOnLoad(gameObject); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int scoreValue)
    {
        GameManager.gameManager.score += scoreValue;

        if(score >= scoreToWin)
        {
            ResetScore();
            SceneManager.LoadScene(3);
        }
    }

    public void ResetScore()
    {
        score = 0;
    }


}
