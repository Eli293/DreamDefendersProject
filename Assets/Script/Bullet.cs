using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public Transform target;

    private void Start()
    {
        if (target == null)
        {
            InvokeRepeating("SpawnBullet", 0f, 0.5f);
        }
    }

    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.target = target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            health.DamagePlayer(damage);
        }

        GetComponent<Collider2D>().enabled = false;
        // Remove the line below to keep the rendering of the bullet intact
        // GetComponent<Renderer>().enabled = false;
    }

}
