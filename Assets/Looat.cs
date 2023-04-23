using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looat : MonoBehaviour
{
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targ = g.transform.position;
        targ.z = 0f;
        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y + objectPos.y;
        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    /*
    void Update()
     {
         Vector3 targ = g.transform.position;
         targ.z = 0f;
         Vector3 objectPos = transform.position;
         targ.x = targ.x + objectPos.x;
         targ.y = targ.y + objectPos.y;
         float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
         Vector3 targetPosition = new Vector3(g.transform.position.x, g.transform.position.y, transform.position.z);
         transform.LookAt(targetPosition);
     }
     */

    /*
    void Update()
    {
        // Get the direction to the target
        Vector3 direction = g.transform.position - transform.position;
        direction.z = 0f;

        // Rotate the turret to look at the target
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
            //transform.Rotate(new Vector3(90, 0, 0));
        }
    }
    */

}



