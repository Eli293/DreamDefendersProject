using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private ConfirmationDialog confirmationDialog;

    private void OnMouseDown()
    {
        // Add this turret to the confirmation dialog's delete list
        confirmationDialog.AddTurretToDelete(this);

        // Show the confirmation dialog
        confirmationDialog.gameObject.SetActive(true);
    }

    public void DeleteTurret()
    {
        // Delete the turret object
        Destroy(gameObject);
    }
}
