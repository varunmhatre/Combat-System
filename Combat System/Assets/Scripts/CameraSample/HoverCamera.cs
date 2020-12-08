using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverCamera : MonoBehaviour
{
    private Transform detachPos;

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            CameraControl.detach = true;
            CameraControl.lockOn = false;
            Time.timeScale = 0.5f;
        }
    }

    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (CameraControl.detach)
            {
                detachPos = Camera.main.transform.GetChild(1);
                Camera.main.transform.GetChild(1).parent = null;
                CameraControl.detach = false;
            }
            CameraControl.Detach(Camera.main.transform, detachPos.position, transform.position);           
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Time.timeScale = 1;
            detachPos.parent = Camera.main.transform;
            detachPos.localPosition = new Vector3(0, 1, -1);
            CameraControl.lockOn = true;
        }
    }
}
