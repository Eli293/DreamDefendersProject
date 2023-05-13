
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 10f;
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float fireCountdown = 0f;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("Shoot", 1f, fireRate);
    }

 


    private void UpdateTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestPlayer = player;
            }
        }

        if (nearestPlayer != null && shortestDistance <= range)
        {
            target = nearestPlayer.transform;
        }
        else
        {
            target = null;
        }
    }


    private void Update()
    {
        if (target == null)
        {
            return;
        }

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            return;
        }

        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null && target != null)
        {
            bullet.target = target.transform;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

