using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    Canvas mainMenu, optionsMenu, audioMenu, advancedMenu, videoMenu;
    

    public void leaveOptions()
    {
        mainMenu.enabled = true;
        optionsMenu.enabled = false;
        audioMenu.enabled = false;
        advancedMenu.enabled = false;
        videoMenu.enabled = false;
    }
    public void audioBtn()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = false;
        audioMenu.enabled = true;
        advancedMenu.enabled = false;
        videoMenu.enabled = false;
    }
    public void videoBtn()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = false;
        audioMenu.enabled = false;
        advancedMenu.enabled = false;
        videoMenu.enabled = true;
    }
    public void advancedBtn()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = false;
        audioMenu.enabled = false;
        advancedMenu.enabled = true;
        videoMenu.enabled = false;
    }
}
