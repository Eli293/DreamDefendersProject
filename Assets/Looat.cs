using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject target; // The enemy to aim at
    public GameObject turretHead; // The head of the turret
    public float rotationSpeed;
    public float angle;

    private bool isPickedAndPlaced = false; // Flag to check if the tower is picked and placed

    // Update is called once per frame
    void Update()
    {
        if (isPickedAndPlaced)
        {
            // Get the direction to the target relative to the head
            Vector3 localTarget = turretHead.transform.InverseTransformPoint(target.transform.position);
            localTarget.y = 0f; // Zero out the y-component of the target direction
            localTarget = localTarget.normalized; // Normalize the direction to get only the horizontal component

            // Get the angle to the target
            float angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

            // Rotate the head to look at the target
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, -angle));
            turretHead.transform.localRotation = Quaternion.RotateTowards(turretHead.transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    // Set the isPickedAndPlaced flag to true when the tower is picked and placed
    public void SetPickedAndPlaced()
    {
        isPickedAndPlaced = true;
    }

    // Reset the isPickedAndPlaced flag when the tower is deselected
    public void SetDeselected()
    {
        isPickedAndPlaced = false;
    }
}
