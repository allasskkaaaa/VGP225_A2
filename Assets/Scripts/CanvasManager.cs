using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
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
}
