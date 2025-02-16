using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PickUp_Score : MonoBehaviour
{
    public int scoreValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.gameManager.score += scoreValue;
            CanvasManager.instance.updateScoreUI();
            Destroy(gameObject);
        }
    }

}
