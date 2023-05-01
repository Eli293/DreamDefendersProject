using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab; // The prefab of the monster to be spawned
    public Transform spawnPosition; // The position where the monsters will spawn
    public int monstersPerWave = 3; // The number of monsters to spawn at once
    public float spawnDelay = 1f; // The delay between monster spawns
    public float spawnInterval = 5f; // The interval between waves of monsters
    public WaypointEditor waypointEditor; // Reference to the waypoint manager for the monsters' path

    private List<GameObject> monsters = new List<GameObject>(); // List to store the spawned monsters

    private void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval); // Wait for the spawn interval before spawning more monsters

            for (int i = 0; i < monstersPerWave; i++) // Spawn the desired number of monsters
            {
                GameObject newMonster = Instantiate(monsterPrefab, spawnPosition.position, Quaternion.identity); // Spawn a monster at the spawn position
                monsters.Add(newMonster); // Add the new monster to the list of spawned monsters
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }

    public void RemoveMonster(GameObject monster)
    {
        monsters.Remove(monster); // Remove the monster from the list of spawned monsters
        Destroy(monster); // Destroy the monster game object
    }

    private void OnDestroy()
    {
        // Destroy any remaining monsters when the spawner is destroyed
        foreach (GameObject monster in monsters)
        {
            Destroy(monster);
        }
    }
}
