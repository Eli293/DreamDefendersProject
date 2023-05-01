using UnityEngine;
using UnityEngine.UI;

public class TowerMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private Button[] towerButtons;

    private GameObject selectedTowerPrefab;

    private void Start()
    {
        // Add click events to the tower buttons
        for (int i = 0; i < towerButtons.Length; i++)
        {
            int index = i;
            towerButtons[i].onClick.AddListener(() => OnTowerButtonClick(index));
        }
    }

    private void OnTowerButtonClick(int index)
    {
        // Set the selected tower based on the index of the button clicked
        selectedTowerPrefab = towerPrefabs[index];
    }

    // Attach this method to the object where the player can place towers
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if a tower has been selected and instantiate it at the position of the mouse click
            if (selectedTowerPrefab != null)
            {
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                clickPosition.z = 0f;

                GameObject tower = Instantiate(selectedTowerPrefab, clickPosition, Quaternion.identity);

                // Call SetPickedAndPlaced() on the LookAt component of the tower
                LookAt lookAt = tower.GetComponentInChildren<LookAt>();
                if (lookAt != null)
                {
                    lookAt.SetPickedAndPlaced();
                }

                // Reset the selectedTowerPrefab
                selectedTowerPrefab = null;
            }
        }
    }
}
