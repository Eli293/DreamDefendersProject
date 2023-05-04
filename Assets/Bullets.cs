using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10;
    public HealthBar hbar;
    public Transform target;

    private void Update()
    {
        // Move towards target if it exists
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            // Destroy bullet if target is null
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hbar.health-= damage;
        }
    }



    /*


    private void OnTriggerEnter(Collider other)
    {
        // Damage target if it has a health component
      HealthBar health = other.GetComponent<HealthBar>();
        if (health != null)
        {
            
        }

        // Destroy bullet on impact
        Destroy(gameObject);
    }
    */
}
