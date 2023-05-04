using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class MonsterPath : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 5f;

    private int currentWaypoint = 0;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = waypoints.Length;
        for (int i = 0; i < waypoints.Length; i++)
        {
            lineRenderer.SetPosition(i, waypoints[i].position);
        }
    }

    private void Update()
    {
        if (currentWaypoint < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, moveSpeed * Time.deltaTime);

            // Update line renderer positions
            for (int i = currentWaypoint; i < waypoints.Length; i++)
            {
                lineRenderer.SetPosition(i, waypoints[i].position);
            }

            if (transform.position == waypoints[currentWaypoint].position)
            {
                currentWaypoint++;
            }
        }
    }
}
