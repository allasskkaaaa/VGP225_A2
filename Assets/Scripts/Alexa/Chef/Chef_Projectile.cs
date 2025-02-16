using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef_Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime;
    private Rigidbody rb;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();

        Destroy(gameObject, lifetime);
    }

    public void Launch(Vector3 force)
    {
        if (rb == null)
        {
            rb = this.GetComponent<Rigidbody>();
        }
        
        rb.AddForce(force, ForceMode.Impulse);
    }

}
