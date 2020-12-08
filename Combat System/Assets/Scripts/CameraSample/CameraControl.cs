using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraControl
{
    public static bool follow = true;
    public static bool lockOn = false;
    public static bool detach = false;

    //Interpotation rates for the following functions
    private static float followSpeed = 8.0f;
    private static float followRotation = 4.0f;
    private static float lockOnSpeed = 4.0f;
    private static float lockOnRotation = 4.0f;
    private static float detachSpeed = 2.0f;
    private static float detachRotation = 2.0f;

    //Lock on parameters
    private static float offset = 1.0f;
    private static Vector3 fixedHeight = new Vector3(0, 0.5f, 0);

    public static void Follow(Transform cam, Transform player, Quaternion camToRot, Vector3 camToPos)
    {
        if (!follow)
            return;

        //Move behind play at given distance from player
        float timeCount = followSpeed * Time.deltaTime;
        camToPos = player.position + new Vector3(0, camToPos.y, 0) + (player.forward * camToPos.z);
        cam.position = Vector3.Lerp(cam.position, camToPos, timeCount);

        //Rotate along with player as it moves left and right 
        //camToRotate allows the camera to look at the player from the given height
        timeCount = followRotation * Time.deltaTime;
        camToRot.eulerAngles += player.rotation.eulerAngles;
        cam.rotation = Quaternion.Slerp(cam.rotation, camToRot, timeCount);
    }

    //player is Player object a looking at object b
    //target is Target object b being locked on by object a
    public static void LockOn(Transform cam, Vector3 player, Vector3 target)
    {
        if (!lockOn)
            return;
        
        //The position of the camera is defined such that:
        //1) Target, Player, and the camera are always in line
        //2) It is always a fixed distance away from Player

        //Get the vector from Target to Player in the plane of the ground
        Vector3 camTo = player - target;

        //Offset to see both Target and Player from a fixed height
        camTo += camTo.normalized * offset + fixedHeight;

        //Place camera at position at a distance from Target for given heading
        float timeCount = lockOnSpeed * Time.deltaTime;
        cam.position = Vector3.Lerp(cam.position, camTo + target, timeCount);
        
        //Make camera look at Target and due to offset, we can see Player too
        timeCount = lockOnRotation * Time.deltaTime;
        cam.forward = Vector3.Lerp(cam.forward, -camTo.normalized, timeCount);        

    }

    //Camera detaches and floats a certain distance from point to lookAt and looks at it
    public static void Detach(Transform cam, Vector3 detachPos, Vector3 lookAt)
    {
        //Camera detaches and floats give distance
        float timeCount = detachSpeed * Time.deltaTime;
        cam.position = Vector3.Lerp(cam.position, detachPos, timeCount);

        //Camera looks at point to lookAt
        timeCount = detachRotation * Time.deltaTime;
        Vector3 camLookAt = lookAt - cam.position;
        cam.forward = Vector3.Lerp(cam.forward, camLookAt.normalized, timeCount);
    }
}
