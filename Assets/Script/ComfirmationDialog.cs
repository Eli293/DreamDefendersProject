using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ConfirmationDialog : MonoBehaviour
{
    [SerializeField] public List<Turret> turretToDelete;
    [SerializeField] private GameObject confirmationPanel;
    [SerializeField] private Button deleteButton;
    [SerializeField] private Button cancelButton;

    private void Awake()
    {
        deleteButton.onClick.AddListener(ConfirmDelete);
        cancelButton.onClick.AddListener(CancelDelete);
    }

    public void AddTurretToDelete(Turret turret)
    {
        // Add turret to delete list
        turretToDelete.Add(turret);
    }

    public void ConfirmDelete()
    {
        // Loop through list and delete each turret
        foreach (Turret turret in turretToDelete)
        {
            Destroy(turret.gameObject);
        }

        // Clear the delete list
        turretToDelete.Clear();

        // Hide the confirmation dialog
        confirmationPanel.SetActive(false);
    }

    public void CancelDelete()
    {
        // Clear the delete list
        turretToDelete.Clear();

        // Hide the confirmation dialog
        confirmationPanel.SetActive(false);
    }
}
