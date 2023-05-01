using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Vector3[] points;
    public Vector3[] Points => points;
    public Vector3 CurrentPosition => currentPosition;
    private Vector3 currentPosition;
    private bool gameStarted;
    private void Start()
    {
        gameStarted = true;
        currentPosition = transform.position;
    }

    public Vector3 GetWaypointPosition(int index)
    {
        return CurrentPosition + Points[index];
    }

    private void OnDrawGizmos()
    {
        if (!gameStarted && transform.hasChanged)
        {
            currentPosition = transform.position;
        }

        for (int i = 0; i < points.Length; i++)
        {

            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(points[i] + currentPosition, 0.5f);

            if (i < Points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + currentPosition, points[i + 1] + currentPosition);
            }

        }

    }

    internal bool IsLastPoint(Vector3 position)
    {
        throw new NotImplementedException();
    }
}