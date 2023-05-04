using UnityEngine;

public class TowerMovement : MonoBehaviour
{
    public string targetTag = "Enemy"; // The tag of the target
    public float range = 10f; // The range of the tower

    private Vector3 initialPosition; // The tower's initial position
    private Transform target; // The current target
    private Quaternion initialRotation; // The tower's initial rotation

    private void Start()
    {
        initialPosition = transform.position; // Save the tower's initial position
        initialRotation = transform.rotation; // Save the tower's initial rotation
    }

    private void FixedUpdate()
    {
        // Prevent rotation and scaling
        transform.rotation = initialRotation;
        transform.localScale = Vector3.one;

        // Find the closest enemy with tag within range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                target = enemy.transform;
            }
        }

        // Check if target is within range and has the given tag
        if (target != null && closestDistance <= range && target.CompareTag(targetTag))
        {
            // Calculate direction to target
            Vector3 direction = target.position - transform.position;

            // Calculate the angle between the current forward direction and the target direction
            float angle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);

            // Rotate the turret around its y-axis towards the target
            transform.RotateAround(transform.position, Vector3.up, angle * Time.fixedDeltaTime * 10f);
        }
    }
}
