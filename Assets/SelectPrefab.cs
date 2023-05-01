using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SelectablePrefab : MonoBehaviour
{
    [SerializeField] private GameObject prefabToInstantiate;
    [SerializeField] private int cost;

    private Vector3 startPos;
    private bool isDragging;
    private GameObject target;

    private void OnMouseDown()
    {
        // Remember the starting position of the prefab and mark it as selected
        startPos = transform.position;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Create a new instance of the prefab and move it with the mouse cursor
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            transform.position = mousePos;
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            // Snap the prefab to the nearest valid location in the game world
            // and deduct the cost of the prefab from the player's resources
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            transform.position = mousePos;

            // TODO: Check if the placement is valid and deduct the cost of the prefab
            // if it is successfully placed

            isDragging = false;

            // Instantiate the tower prefab and set it as the target of the LookAt script
            GameObject tower = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
            LookAt lookAt = tower.GetComponentInChildren<LookAt>();
            if (lookAt != null)
            {
                lookAt.target = target;
                lookAt.SetPickedAndPlaced(); // Set the isPickedAndPlaced flag to true
            }
        }
    }
}
