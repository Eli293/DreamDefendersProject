using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Waypoint waypoint;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 0f;
    [SerializeField] private float waypointRadius = 0.1f;

    private int currentWaypointIndex = 0;
    private Vector3 currentWaypoint;

    private void Start()
    {
        currentWaypoint = waypoint.GetWaypointPosition(currentWaypointIndex);
    }

    private void Update()
    {
        // Check if the character has reached the current waypoint
        if (Vector3.Distance(transform.position, currentWaypoint) <= waypointRadius)
        {
            // Move to the next waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoint.Points.Length)
            {
                currentWaypointIndex = 0;
            }
            currentWaypoint = waypoint.GetWaypointPosition(currentWaypointIndex);
        }

        // Calculate the direction to the current waypoint
        Vector3 targetDirection = currentWaypoint - transform.position;

        // Rotate towards the target direction
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move towards the current waypoint using interpolation
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
    }
}
