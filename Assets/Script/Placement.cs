using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerOptionsPanel;
    public GameObject towerPrefab;

    public void OnClick()
    {
        // Show the tower options panel
        towerOptionsPanel.SetActive(true);
    }

    public void OnTowerSelected()
    {
        // Hide the tower options panel
        towerOptionsPanel.SetActive(false);

        // Instantiate the tower prefab at the position of this game object
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
    }
}
