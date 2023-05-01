using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the monster moves
    public WaypointEditor waypointEditor; // Reference to the waypoint manager for the monster's path
    public MonsterSpawner monsterSpawner; // Reference to the monster spawner that spawned the monster

    private int currentWaypointIndex = 0; // The index of the current waypoint
    private List<Transform> waypoints = new List<Transform>(); // List to store the waypoints in the monster's path

    private void Start()
    {
        // Get the waypoints from the waypoint manager
        foreach (Transform waypoint in waypointEditor.waypoints)
        {
            waypoints.Add(waypoint);
        }
    }

    private void Update()
    {
        // Move towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

        // Check if the monster has reached the current waypoint
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            currentWaypointIndex++;

            // If the monster has reached the end of the path, destroy it
            if (currentWaypointIndex >= waypoints.Count)
            {
                monsterSpawner.RemoveMonster(gameObject); // Remove the monster from the spawner's list of spawned monsters
                Destroy(gameObject); // Destroy the monster game object
            }
        }
    }
}
