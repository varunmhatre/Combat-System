using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetMoveTowards : MonoBehaviour, IFollowTarget
{
    //Interpotation rates for the following functions
    private static float followSpeed = 1.0f;
    private static float followDistance = 1.0f;

    public void Follow(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) > followDistance)
        {
            Vector3 objectToPos = new Vector3(target.position.x, transform.position.y, target.position.z);

            transform.position = Vector3.MoveTowards(transform.position, objectToPos, followSpeed * Time.deltaTime);
            transform.LookAt(objectToPos); 
        }        
    }
}
