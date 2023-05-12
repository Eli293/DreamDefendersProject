using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bullet : MonoBehaviour
{
  
    public float damageAmount = 10f;
    internal Transform target;

    FloatingHealthBar floatingHealth;
    

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        
        


        if (floatingHealth != null)
        {
            floatingHealth.TakeDamage(damageAmount);
        }

        // Destroy the bullet object after collision or add your own logic
        Destroy(gameObject);
    }
}

