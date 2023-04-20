using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthbar;
    public float healthAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {
        healthbar.fillAmount = healthAmount / 100f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthbar.fillAmount = healthAmount / 100f;
    }


    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthbar.fillAmount+= healingAmount;
    }
}
