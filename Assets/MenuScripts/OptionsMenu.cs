using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    Canvas mainMenu, optionsMenu, audioMenu,videoMenu;
    

    public void leaveOptions()
    {
        mainMenu.enabled = true;
        optionsMenu.enabled = false;
        audioMenu.enabled = false;
        videoMenu.enabled = false;
    }
    public void audioBtn()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = false;
        audioMenu.enabled = true;
        videoMenu.enabled = false;
    }
    public void videoBtn()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = false;
        audioMenu.enabled = false;
        videoMenu.enabled = true;
    }
    public void advancedBtn()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = false;
        audioMenu.enabled = false;
        videoMenu.enabled = false;
    }
    
}
