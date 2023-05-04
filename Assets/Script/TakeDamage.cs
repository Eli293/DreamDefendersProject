
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public HealthBar healthBar;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            healthBar.FillAmountImage.fillAmount = (float)health / -0.1f;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a bullet
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            // Take damage and remove bullet
            TakeDamage(bullet.damage);
            Destroy(bullet.gameObject);
        }
    }
}
