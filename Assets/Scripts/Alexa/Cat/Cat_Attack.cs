using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Attack : Cat_BaseState
{

    Rigidbody rb;

    private bool hasPounced;
    private float cooldownTimer;
    private float timer;
    private bool soundPlayed;

    public override void EnterState(Cat_StateManager cat)
    {
        Debug.Log("Entering Attack State");
        rb = cat.gameObject.GetComponent<Rigidbody>();

        cooldownTimer = cat.pounceCooldown;
        timer = cat.pounceCooldown;
        hasPounced = false;
        soundPlayed = false;
    }

    public override void UpdateState(Cat_StateManager cat)
    {
        if (!hasPounced)
        {
            pounce(cat);
            hasPounced = true;
        }
        else
        {
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            else
            {
                cat.SwitchState(cat.searchState);
            }
        }

    }

    public void pounce(Cat_StateManager cat)
    {
        Debug.Log("Pouncing!");
        cat.StartCoroutine(PounceCoroutine(cat));
    }

    private IEnumerator PounceCoroutine(Cat_StateManager cat)
    {
        Vector3 startPos = cat.transform.position;
        Vector3 pounceDirection = cat.transform.forward.normalized; // Store initial direction
        float speed = 5f;  // Set pounce speed
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (!soundPlayed)
            {
                soundPlayed = true;
                SoundManager.instance.PlayClip(cat.pounceSound);
            }
            cat.anim.Play("Jump");
            
            rb.velocity = pounceDirection * (speed / duration); // Use fixed direction
            elapsed += Time.deltaTime;
            yield return null;
        }

        rb.velocity = Vector3.zero; // Stop movement
        cat.SwitchState(cat.searchState);
        Debug.Log("Pounce Complete!");
    }


    public override void OnTriggerEnter(Cat_StateManager cat, Collider collision)
    {
        
    }

    public override void OnTriggerStay(Cat_StateManager cat, Collider collision)
    {
        
    }

    public override void OnTriggerExit(Cat_StateManager cat, Collider collision)
    {

    }
}
