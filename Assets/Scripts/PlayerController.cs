using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static CharacterController playerController;
    public float movementSpeed = 5;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public static bool canMove = true;
    float gravity;
    float gravityStrength = 9.81f;

    float jumpTimer = 0;




    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        playerController = GetComponent<CharacterController>();
	}

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
           // Cursor.visible = true;
        }

        gravity -= gravityStrength * Time.deltaTime;
        playerController.Move(new Vector3(0, gravity* Time.deltaTime, 0));




        if (playerController.isGrounded)
        {
            gravity = 0;
        }
        if (canMove)
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            //pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

            if (Input.GetKey(KeyCode.W))
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                playerController.Move(forward * (movementSpeed / 10));
            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 backward = transform.TransformDirection(Vector3.back);
                playerController.Move(backward * (movementSpeed / 10));
            }
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 left = transform.TransformDirection(Vector3.left);
                playerController.Move(left * (movementSpeed / 10));
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 right = transform.TransformDirection(Vector3.right);
                playerController.Move(right * (movementSpeed / 10));

            }
            if (Input.GetKey(KeyCode.Space) && jumpTimer < -0.4)
            {
                jumpTimer = 0.5f;
            }
        }
        

        if (jumpTimer > 0 && jumpTimer > 0.15f)
        {
            Jump(1);
            if(jumpTimer > 0 && jumpTimer <= 0.15f)
            {
                Jump(0);
            }
        }
        jumpTimer -= Time.deltaTime;
    }
    
    private void Jump(int speed)
    {
        if(speed == 1)
        {
            Vector3 jump = new Vector3(0, 10, 0);
            playerController.Move(jump * Time.deltaTime);
        }
        if (speed == 0)
        {
            Vector3 jump = new Vector3(0, 5, 0);
            playerController.Move(jump * Time.deltaTime);
        }

    }
}
