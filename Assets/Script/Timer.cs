using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

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
        Time.timeScale = 1f; // Set time scale to 1 in case it was paused in a previous scene
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            if (loseCanvas.enabled)
            {
                // Handle lose condition
            }
            else
            {
                currentTime = 0;
                winCanvas.enabled = true;
                Time.timeScale = 0f; // Pause the game
                StartCoroutine(SwitchSceneWithDelay());
            }
        }

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator SwitchSceneWithDelay()
    {
        yield return new WaitForSeconds(3f); // Delay for 3 seconds
        SceneManager.LoadScene("OtherScene"); // Replace "OtherScene" with the name of your next scene
    }
}
