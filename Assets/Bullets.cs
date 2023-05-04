using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
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


   private void OnTriggerEnter(Collider other)
    {
        // Damage target if it has a health component
        TakeDamage health = other.GetComponent<TakeDamage>();
        if (health != null)
        {
            health.Takehit(damage);
        }

        // Destroy bullet on impact
        Destroy(gameObject);
    }
}
