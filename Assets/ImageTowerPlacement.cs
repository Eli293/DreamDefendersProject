using UnityEngine;
using UnityEngine.UI;

public class ImageTowerPlacement : MonoBehaviour
{
    [SerializeField] private GameObject towerPanel;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button[] towerButtons;
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private float yOffset;

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
        // Open the tower panel when the image is clicked
        towerPanel.SetActive(true);
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

        // Check if a tower has been selected and instantiate it at the position of the image
        if (selectedTower != null)
        {
            Vector3 towerPosition = transform.position + new Vector3(0f, yOffset, 0f);
            Instantiate(selectedTower, towerPosition, Quaternion.identity);
            Debug.Log("Tower instantiated at position: " + towerPosition);

            // Adjust the tower's position to be relative to the image's position
            GameObject lastTower = GameObject.FindWithTag("Tower");
            if (lastTower != null)
            {
                lastTower.transform.position = new Vector3(transform.position.x, transform.position.y, lastTower.transform.position.z);
            }
        }
    }


}
