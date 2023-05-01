using UnityEngine;
using UnityEngine.UI;

public class ConfirmationDialog : MonoBehaviour
{
    [SerializeField] public Turret turretToDelete;
    [SerializeField] private GameObject confirmationPanel;
    [SerializeField] private Button deleteButton;
    [SerializeField] private Button cancelButton;

    private void Awake()
    {
        deleteButton.onClick.AddListener(ConfirmDelete);
        cancelButton.onClick.AddListener(CancelDelete);
    }

    public void ConfirmDelete()
    {
        // Delete the turret
        Destroy(turretToDelete.gameObject);

        // Hide the confirmation dialog
        confirmationPanel.SetActive(false);
    }

    public void CancelDelete()
    {
        // Hide the confirmation dialog
        confirmationPanel.SetActive(false);
    }
}
