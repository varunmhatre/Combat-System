using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector3 camToPos;
    Quaternion camToRot;

    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0)
            speed = 0.02f;

        camToRot.eulerAngles = new Vector3(10, 0, 0);
        camToPos = new Vector3(0, 0.2f, -0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        KeyPress(Input.anyKey);
    }

    private void KeyPress(bool anyKey)
    {
        //Key control
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.up, -speed * 100, Space.Self);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up, speed * 100, Space.Self);
        }

        CameraControl.Follow(Camera.main.transform, transform, camToRot, camToPos);
    }

}