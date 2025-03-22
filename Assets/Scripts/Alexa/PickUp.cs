using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PickUp_Score : MonoBehaviour
{
    public int scoreValue;

    [SerializeField] private AudioClip pickupSoundEffect;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Animator anim = other.GetComponent<Animator>();

            if (anim != null)
                anim.Play("Eat");

            GameManager.gameManager.addScore(scoreValue);
            CanvasManager.instance.updateScoreUI();
            SoundManager.instance.PlayClip(pickupSoundEffect);
            Destroy(gameObject);
        }
    }

}
