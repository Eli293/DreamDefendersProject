using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public List<Image> hearts;

    private int currentHearts;

    private void Start()
    {
        currentHearts = hearts.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (currentHearts > 0)
            {
                currentHearts--;
                hearts[currentHearts].gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Game Over!");
                // Add game over logic here
            }
        }
    }
}
