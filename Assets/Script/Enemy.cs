using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float health, maxHealth = 3f;
    Rigidbody2D rb;


    [SerializeField] FloatingHealthBar healthbar;


    private void Start()
    {
        health = maxHealth;
        
           

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthbar= GetComponentInChildren<FloatingHealthBar>();

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.updateHealthBar(health, maxHealth);
        if (health <=0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
