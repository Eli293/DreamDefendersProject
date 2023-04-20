using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        Move();
        Rotate();
        if (CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }
    }

    // Update is called once per frame
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, CurrentPointPosition MoveSpeed * Time.deltaTime);
    }
}
    private void Rotate()
{
    if (CurrentPointPosition.x > lastPointPosition.x) {
        SpriteRenderer.flipX = false;

    }
    else
    {
        SpriteRenderer.flipX = true;
    }
}
      private bool CurrentPointPositionReached()
        {
            float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
            if(distanceToNextPointPosition < 0.1f)
            {
                lastPointPosition = transform.position;
                return true;
            }
            return false;
        }
}
        private void UpdateCurrentPointIndex()
        {
            int lastWaypointIndex = Waypoint.Points.Length = 1;
            if (currentWaypointIndex < lastWaypointIndex)
            {
                currentWaypointIndex++;
            }
            else
            {
                EndPointReached();
            }
        }
private void EndPointReached()
{
    OnEndReached?.Invoke(this);
    EnnemyHealth.ResetHealth();
    ObjectPooler.ReturnToPool(GameObject);
}
    
