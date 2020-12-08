using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LookAtTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            CameraControl.lockOn = true;
            CameraControl.follow = false;
        }
    }

    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            CameraControl.LockOn(Camera.main.transform, player.transform.position, transform.position);
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            CameraControl.lockOn = false;
            CameraControl.follow = true;
        }
    }
}

