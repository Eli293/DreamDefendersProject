using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownTime = 60f;
    public Canvas winCanvas;
    public Canvas loseCanvas;

    public string nextSceneName; // Name of the scene to switch to

    private float currentTime;
    private bool sceneSwitched = false;

    void Start()
    {
        currentTime = countdownTime;
        winCanvas.enabled = false;
        loseCanvas.enabled = false;
    }

    void Update()
    {
        if (sceneSwitched)
        {
            // If the scene has already been switched, exit the method
            return;
        }

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            if (loseCanvas.enabled)
            {
                // Handle losing condition here
            }
            else
            {
                currentTime = 0;
                winCanvas.enabled = true;
                Time.timeScale = 0;

                // Switch to the next scene after a delay
                StartCoroutine(SwitchSceneAfterDelay());
            }
        }

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 100f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator SwitchSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f); // Adjust the delay as needed

        // Switch to the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
