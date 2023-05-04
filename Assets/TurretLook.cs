using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLook : MonoBehaviour
{
    public string targetTag = "Enemy";
    public float range = 10f;
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Transform target;
    private float fireCountdown = 0f;

    private void Start()
    {
        // Find initial target with tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                target = enemy.transform;
            }
        }
    }

    private void Update()
    {
        // Find the closest enemy with tag within range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                target = enemy.transform;
            }
        }

        // Check if target is within range and has the given tag
        if (target != null && closestDistance <= range && target.CompareTag(targetTag))
        {
            // Calculate direction to target
            Vector3 direction = target.position - transform.position;

            // Calculate the angle between the current forward direction and the target direction
            float angle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);

            // Calculate the rotation speed based on the angle and fire rate
            float rotationSpeed = Mathf.Clamp(angle / fireRate, -1f, 1f);

            // Rotate the turret around its y-axis towards the target
            transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime * 100f);

            // Fire bullet if ready
            if (fireCountdown <= 0f)
            {
                Fire();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    private void Fire()
    {
        // Spawn bullet prefab at fire point
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullets bullet = bulletGO.GetComponent<Bullets>();

        // Set bullet target
        if (bullet != null)
        {
            bullet.target = target;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw range gizmo in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
