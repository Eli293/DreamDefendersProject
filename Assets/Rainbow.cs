using UnityEngine;

public class RainbowLaser : MonoBehaviour
{
    public float damagePerSecond = 10f;
    public float range = 5f;
    public float fireRate = 1f;
    public LineRenderer lineRenderer;
    public Gradient gradient;

    private Transform target;
    private float fireCountdown = 0f;

    private void Start()
    {
        lineRenderer.colorGradient = gradient;
    }

    private void Update()
    {
        if (fireCountdown <= 0f)
        {
            UpdateTarget();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, target.position);

            DamageEnemy(target, damagePerSecond * Time.deltaTime);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= range)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
            lineRenderer.enabled = true;
        }
        else
        {
            target = null;
        }
    }

    private void DamageEnemy(Transform enemy, float damage)
    {
        // Apply damage to the enemy here
        // You can use the enemy's script or components to handle health/damage
        // Example: enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
    }
}
