using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;
    public float towerCost = 100f;
    public LayerMask groundLayer;
    public GameObject[] scriptsToEnable;

    private bool isPlacing = false;
    private GameObject currentTower;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, groundLayer))
            {
                if (isPlacing)
                {
                    if (CanPlaceTower(hit.point))
                    {
                        PlaceTower(hit.point);
                        EnableScripts();
                    }
                }
            }
        }
    }

    private bool CanPlaceTower(Vector3 position)
    {
        // Check if tower can be placed at position
        // For example, you can check if there are any obstacles in the way

        return true;
    }

    private void PlaceTower(Vector3 position)
    {
        // Spawn tower prefab at position
        currentTower = Instantiate(towerPrefab, position, Quaternion.identity);
        isPlacing = false;
    }

    private void EnableScripts()
    {
        // Enable scriptsToEnable
        foreach (GameObject script in scriptsToEnable)
        {
            script.GetComponent<MonoBehaviour>().enabled = true;
        }
    }
}
