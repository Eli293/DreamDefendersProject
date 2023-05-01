using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public int maxHealth = 3;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHearts(int health)
    {
        currentHealth = health;

        if (currentHealth >= 3)
        {
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = true;
        }
        else if (currentHealth == 2)
        {
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = false;
        }
        else if (currentHealth == 1)
        {
            heart1.enabled = true;
            heart2.enabled = false;
            heart3.enabled = false;
        }
        else
        {
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
        }
    }
}
