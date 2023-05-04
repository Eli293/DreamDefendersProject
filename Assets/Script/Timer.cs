using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownTime = 60f;
    public Canvas winCanvas;
    public Canvas loseCanvas;

    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
        winCanvas.enabled = false;
        loseCanvas.enabled = false;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            if (loseCanvas.enabled)
            {
               
            }
            else
            {
                currentTime = 0;
                winCanvas.enabled = true;
                Time.timeScale = 0;
            }
        }

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
