using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    public static Action<Enemy> OnEnemyKilled;
    public static Action<Enemy> OnEnemyHit;
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;
    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;
    public float CurrentHealth
    {
        get;
        set;
    }
    private Image healthBar;
    private Enemy enemy;
   private void Start()
    {
        CreateHealthBar();
        CurrentHealth = initialHealth;
        enemy = GetComponent<Enemy> ();

        
    }

    // Update is called once per frame
    private void Update()
    { if (Input.GetKeyDown(KeyCode.P))
        {
            DealDamage(5f);
        }
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, CurrentHealth / maxHealth, Time.deltaTime * 10f);
    }
    private void CreateHealthBar()
    {
        GameObject newBar = Instantiate(healthBarPrefab, barPosition.position, Quaternion.identity);
        newBar.transform.SetParent(transform);
        EnemyHealthContainer container = newBar.GetComponent<EnemyHealthContainer>();
        healthBar = container.FillAmountImage;

    }
    private void DealDamage(float damageReceived)
    {
        CurrentHealth -= damageReceived;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
        else
            OnEnemyHit?.Invoke(enemy);
    }
        
    }

