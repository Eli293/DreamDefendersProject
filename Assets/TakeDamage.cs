
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
}
