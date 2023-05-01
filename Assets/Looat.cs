using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject target; // The enemy to aim at
    public GameObject head; // The head of the turret
    public float rotationSpeed;
    public float angle;

    // Update is called once per frame
    void Update()
    {
        // Get the direction to the target relative to the head
        Vector3 localTarget = head.transform.InverseTransformPoint(target.transform.position);
        localTarget.z = 0f;

        // Get the angle to the target
        float angle = Mathf.Atan2(localTarget.y, localTarget.x) * Mathf.Rad2Deg;

        // Rotate the head to look at the target
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        head.transform.rotation = Quaternion.RotateTowards(head.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
