using UnityEngine;

public class LaserTower : MonoBehaviour
{
    public float damagePerSecond = 10f;
    public float range = 5f;
    public float fireRate = 1f;
    public LineRenderer lineRenderer;
    public Material lineMaterial; // Assign a material with desired color and transparency

    private Transform target;
    private float fireCountdown = 0f;
    private HealthBar healthBar;

    private void Start()
    {
        lineRenderer.material = lineMaterial;
        healthBar = FindObjectOfType<HealthBar>();
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
        Health enemyHealth = enemy.GetComponent<Health>();
        if (enemyHealth != null)
        {
            enemyHealth.DamagePlayer((int)damage);
            healthBar.SetHealth(enemyHealth.curHealth);
        }
    }
}
