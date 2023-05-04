using UnityEngine;

public class Tower : MonoBehaviour
{
    public float towerHeight = 1f; // The height of the tower (used to adjust the pivot point)
    public float placementDistance = 10f; // The distance from the camera to place the tower
    private bool isPlaced = false; // Whether the tower has been placed on the map

    private void Update()
    {
        if (!isPlaced)
        {
            // Get the mouse position in screen coordinates
            Vector3 mousePositionScreen = Input.mousePosition;

            // Get the distance between the camera and the tower
            float distanceToTower = Vector3.Distance(Camera.main.transform.position, transform.position);

            // Calculate the placement position based on the distance and the mouse position
            Vector3 placementPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, mousePositionScreen.y, distanceToTower));

            // Adjust the tower height to align with the ground plane
            placementPosition.y = towerHeight / 2f;

            // Move the tower to the placement position
            transform.position = placementPosition;

            // Place the tower on left mouse button click
            if (Input.GetMouseButtonDown(0))
            {
                isPlaced = true;
                PlaceTower();
            }
        }
    }

    private void PlaceTower()
    {
        // Get the distance between the camera and the tower
        float distanceToTower = Vector3.Distance(Camera.main.transform.position, transform.position);

        // Calculate the placement position and rotation
        Vector3 placementPosition = Camera.main.transform.position + Camera.main.transform.forward * placementDistance;
        Quaternion placementRotation = Quaternion.LookRotation(transform.position - placementPosition, Vector3.up);

        // Set the tower position and rotation to the placement position and rotation
        transform.position = placementPosition;
        transform.rotation = placementRotation;
    }
}
