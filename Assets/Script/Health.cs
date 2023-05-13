using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;


public class Health : MonoBehaviour
{
    public int curHealth = 20;
    public int maxHealth = 50;
    public HealthBar healthBar;
  
    void Start()
    {
        curHealth = maxHealth;
    }
    void Update()
    {
        
    }
    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);

        Die();
    }


    public void Die()
    {
        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}

