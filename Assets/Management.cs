using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public List<GameObject> availableTowers;
    public GameObject currentTower;
    public GameObject towerMenu;

    private bool towerMenuOpen;

    void Start()
    {
        towerMenu.SetActive(false);
        towerMenuOpen = false;
    }

    void Update()
    {
        if (towerMenuOpen && Input.GetMouseButtonDown(0))
        {
            towerMenu.SetActive(false);
            towerMenuOpen = false;
            return;
        }

        if (currentTower != null && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Ground")
                {
                    Instantiate(currentTower, hit.point, Quaternion.identity);
                    currentTower = null;
                }
            }
        }
    }

    public void OpenTowerMenu()
    {
        if (!towerMenuOpen)
        {
            towerMenu.SetActive(true);
            towerMenuOpen = true;
        }
    }

    public void SetCurrentTower(int towerIndex)
    {
        if (towerIndex >= 0 && towerIndex < availableTowers.Count)
        {
            currentTower = availableTowers[towerIndex];
            towerMenu.SetActive(false);
            towerMenuOpen = false;
        }
    }
}
