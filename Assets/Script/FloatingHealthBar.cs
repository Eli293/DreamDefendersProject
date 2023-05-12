using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Slider slider;

    [SerializeField]
    float health, maxHealth = 3f;
    [NonSerialized]
    public Rigidbody2D rb;

    [NonSerialized] FloatingHealthBar healthbar;


    private void Start()
    {
        health = maxHealth;



    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthbar = GetComponentInChildren<FloatingHealthBar>();

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.updateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


    public void updateHealthBar(float currentValue, float maxValue)

    {
       slider.value = currentValue /maxValue;

    }

    
}
