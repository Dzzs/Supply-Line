using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private bool isFirstPerson = false;

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerController.canMove)
        {
            //yaw += speedH * Input.GetAxis("Mouse X");
            yaw = player.transform.eulerAngles.y;
            pitch -= speedV * Input.GetAxis("Mouse Y");

            if (pitch > -51 && pitch < 61)
            {
                transform.eulerAngles = new Vector3(Mathf.Clamp(pitch, -50.0f, 60.0f), yaw, 0.0f);
            }



            if (Input.GetAxis("Mouse ScrollWheel") > 0 && isFirstPerson == false)
            {
                if (transform.localPosition.y >= 1.0f)
                {
                    transform.localPosition += new Vector3(0.0f, -0.1f, 0.1f);
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && isFirstPerson == false)
            {
                if (transform.localPosition.y <= 2f)
                {
                    transform.localPosition += new Vector3(0.0f, 0.1f, -0.1f);
                }
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                if (isFirstPerson == false)
                {
                    isFirstPerson = true;
                    transform.localPosition = new Vector3(0, 1, 0.1f);
                    transform.Rotate(new Vector3(-25.0f, 0.0f, 0.0f));

                    return;
                }
                if (isFirstPerson == true)
                {
                    isFirstPerson = false;
                    transform.localPosition = new Vector3(0, 1.2f, -2.0f);
                    transform.Rotate(new Vector3(25.0f, 0.0f, 0.0f));
                    return;
                }

            }
        }
    }
}
