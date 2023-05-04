using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int health = 10;
    public HealthBar healthBar;

    public void Takehit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            healthBar.FillAmountImage.fillAmount = (float)health / 10f;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with a bullet
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            // Take damage and remove bullet
            Takehit(10);
            Destroy(bullet.gameObject);
        }
    }
}





