using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [NonSerialized]
    public Timer timer;
    public int playerHealth;
    [SerializeField] 
    private Image[] hearts;



    // Start is called before the first frame update
   private void Start()
    {
        UpdateHealth();

    }



    public void UpdateHealth()
    {
        if (playerHealth <= 0) 
        {
           timer.currentTime = 0;
               timer.loseCanvas.enabled = true;
                Time.timeScale = 0f;
                

        }

        for (int i = 0; i < hearts.Length; i++)
            {
                if (i < playerHealth)
                {
                    hearts[i].color = Color.red;
                }

                else
                {
                    hearts[i].color = Color.black;
                }
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
