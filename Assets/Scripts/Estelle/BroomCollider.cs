using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomCollider : MonoBehaviour
{
    [SerializeField] float DestroyAfter = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyAfter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
