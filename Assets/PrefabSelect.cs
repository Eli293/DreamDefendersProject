
using UnityEngine;


public class PrefabSelector : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to spawn

    private bool isPrefabSelected = false; // Flag to check if the prefab is selected

    private void Update()
    {
        if (isPrefabSelected && Input.GetMouseButtonDown(0))
        {
            // Spawn the prefab at the mouse position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            Instantiate(prefabToSpawn, mousePos, Quaternion.identity);

            // Deselect the prefab
            isPrefabSelected = false;
        }
    }

    // Call this method from the menu option to select the prefab
    public void SelectPrefab()
    {
        isPrefabSelected = true;
    }
}
