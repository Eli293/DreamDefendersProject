using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public  float health;
    public float maxhealth;
    public Image healthBar;








    void Start()
    {
        maxhealth = health;
    }


     void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxhealth, 0, 1);
    }
    






}
