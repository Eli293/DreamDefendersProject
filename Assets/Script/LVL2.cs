using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public float delaySeconds = 3f; // Delay in seconds before switching scenes

    public void SwitchSceneWithDelay()
    {
        Invoke("SwitchScene", delaySeconds);
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene("Lvl2");
    }
}
