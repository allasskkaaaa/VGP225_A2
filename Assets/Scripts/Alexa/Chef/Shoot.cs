using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private List<Chef_Projectile> projectiles = new List<Chef_Projectile>(); //All possible objects to throw
    [SerializeField] public Transform throwPoint; //Point from which the projectile is thrown
    [SerializeField] private float throwForce = 10f;
    

    public void ThrowProjectile()
    {
        int randomProjectile = Random.Range(0, projectiles.Count);
        GameObject projectileInstance = Instantiate(projectiles[randomProjectile].gameObject, throwPoint.position, throwPoint.rotation); 
        Chef_Projectile projectileScript = projectileInstance.GetComponent<Chef_Projectile>();  

        if (projectileScript != null)
        {
            Vector3 throwDirection = throwPoint.forward;

            projectileScript.Launch(throwDirection * throwForce);
        }
    }
}
