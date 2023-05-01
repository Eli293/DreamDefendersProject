using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private ConfirmationDialog confirmationDialog;

    private void OnMouseDown()
    {
        // Show the confirmation dialog
        confirmationDialog.gameObject.SetActive(true);

        // Pass a reference to this turret to the confirmation dialog
        confirmationDialog.turretToDelete = this;
    }

    public void DeleteTurret()
    {
        // Delete the turret object
        Destroy(gameObject);
    }
}
