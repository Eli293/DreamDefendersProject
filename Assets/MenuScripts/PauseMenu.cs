using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    bool isPaused = false;
    [SerializeField]
    GameObject PauseCanvas;

    public Canvas options;
    public Canvas winCanvas;
    public Canvas loseCanvas;
    void Start()
    {
        winCanvas.enabled = false;
        loseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (winCanvas.enabled || loseCanvas.enabled)
            {

            }
            else
            {
                if (isPaused)
                {
                    ResumeMe();
                }
                else
                {
                    PauseMe();
                }
            }
        }
        
    }
    public void PauseMe()
    {
        Time.timeScale = 0;
        isPaused = true;
        PauseCanvas.SetActive(true);
    }
    public void ResumeMe()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseCanvas.SetActive(false);
    }
    public void OptionsMe()
    {
        Time.timeScale = 0;
        isPaused= true;
        options.enabled = true;
        loseCanvas.enabled = false;
        winCanvas.enabled= false;
    }

}
