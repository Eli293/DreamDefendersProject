using UnityEngine;

public class ClickableTower : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isClicked;

    private void Start()
    {
        initialPosition = transform.position;
        isClicked = false;
    }

    private void OnMouseDown()
    {
        // Remember the initial position of the tower when it is clicked
        isClicked = true;
    }

    // Attach this method to the object where the player can place towers
    private void Update()
    {
        if (isClicked)
        {
            // Update the tower position only if it has been clicked by the player
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0f;
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        // Reset the tower position when the mouse button is released
        transform.position = initialPosition;
        isClicked = false;
    }
}
