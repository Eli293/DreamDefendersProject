using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Transform target;

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Calculate the direction towards the target
        Vector3 direction = (target.position - transform.position).normalized;

        // Move the bullet towards the target
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Check if the bullet has reached the target
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= 0.1f) // Adjust the threshold as needed
        {
            HitTarget();
        }
    }

    private void HitTarget()
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            health.DamagePlayer(damage);
        }

        Destroy(gameObject);
    }
}
