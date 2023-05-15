using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance= this;
    }



    // Start is called before the first frame update
    void Start()
    { 
        GetComponent<IMPScript>().Init();
    }


    // Update is called once per frame
   
}
