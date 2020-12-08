using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour, IFollowTarget
{
    //Interpotation rates for the following functions
    private static float followSpeed = 1.0f;
    private static float followDistance = 1.0f;

    public void Follow(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) > followDistance)
        {
            Vector3 objectToPos = new Vector3(target.position.x, transform.position.y, target.position.z);
            var dir = (objectToPos - transform.position).normalized;

            transform.position += dir * followSpeed * Time.deltaTime;
            transform.LookAt(objectToPos);

        }        
    }
}
