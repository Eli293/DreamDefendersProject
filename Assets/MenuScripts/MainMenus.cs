using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenus : MonoBehaviour
{
    [SerializeField]
    Canvas mainMenu, optionsMenu;



    public void Start()
    {
       mainMenu.enabled = true;
       optionsMenu.enabled = false;
    }

    public void optionsMenuInvoke()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = true;
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void quitGame()
    {
        Application.Quit();
    }
}
