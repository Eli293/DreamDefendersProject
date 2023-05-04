using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTransparent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deleteCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the delete canvas so it's not visible at the start of the game
        deleteCanvas.SetActive(false);
    }
}