using UnityEngine;
using UnityEngine.UI;

public class ImageTowerPlacement : MonoBehaviour
{
    [SerializeField] private GameObject towerPanel;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button[] towerButtons;
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private float yOffset;

    private bool towerPlaced = false; // Flag to track if a tower has been placed
    private GameObject selectedTower;

    private void Start()
    {
        // Disable the tower panel and add click events to the tower buttons
        towerPanel.SetActive(false);

        for (int i = 0; i < towerButtons.Length; i++)
        {
            int index = i;
            towerButtons[i].onClick.AddListener(() => OnTowerButtonClick(index));
        }

        // Add a click event to the close button
        closeButton.onClick.AddListener(CloseTowerPanel);
    }

    private void OnMouseDown()
    {
        // Only open the tower panel if a tower hasn't been placed
        if (!towerPlaced)
        {
            towerPanel.SetActive(true);
        }
    }

    private void CloseTowerPanel()
    {
        // Close the tower panel and reset the selected tower
        towerPanel.SetActive(false);
        selectedTower = null;
    }

    private void OnTowerButtonClick(int index)
    {
        // Set the selected tower based on the index of the button clicked
        selectedTower = towerPrefabs[index];

        // Close the tower panel
        CloseTowerPanel();
    }

    private void OnMouseUp()
    {
        // Check if a tower has been selected and instantiate it at the position of the mouse cursor
        if (selectedTower != null)
        {
            // Get the position of the mouse cursor in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Offset the tower position by the y-offset and snap to the grid
            Vector3 towerPosition = new Vector3(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y + yOffset), 0f);

            // Instantiate the tower at the snapped position
            GameObject towerObject = Instantiate(selectedTower, towerPosition, Quaternion.identity);
            Debug.Log("Tower instantiated at position: " + towerPosition);

            // Set the flag to indicate that a tower has been placed
            towerPlaced = true;

            // Adjust the tower's position to be relative to the image's position
            towerObject.transform.position = new Vector3(transform.position.x, transform.position.y, towerObject.transform.position.z);

            // Enable any necessary components or scripts on the tower object
           LookAt towerBehavior = towerObject.GetComponent<LookAt>();
            if (towerBehavior != null)
            {
                towerBehavior.enabled = true;
            }

            // Add any additional scripts or components that need to be enabled here
        }
    }

}

