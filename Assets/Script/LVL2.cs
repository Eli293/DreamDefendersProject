using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public float delaySeconds = 3f; // Delay in seconds before switching scenes
    private float timer = 0f; // Timer value to be stored and retrieved

    public void SwitchSceneWithDelay()
    {
        timer = Time.time; // Store the current timer value
        Invoke("SwitchScene", delaySeconds);
    }

    private void SwitchScene()
    {
        PlayerPrefs.SetFloat("Timer", timer); // Store the timer value in PlayerPrefs
        SceneManager.LoadScene("Lvl2");
    }
}
