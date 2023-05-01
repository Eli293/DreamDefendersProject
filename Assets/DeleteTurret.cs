using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDeletion : MonoBehaviour
{
    public void DeleteTurret()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DeleteTurret();
        }
    }
}
