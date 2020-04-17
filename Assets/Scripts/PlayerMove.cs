using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController playerController;

    public float moveSpeed = 5f;
    public float jumpHeight = 2f;

    public bool isOnGround = true;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask ground;

    public Vector3 velocity;

    public float gravity = -9.81f;

    void doJump()
    {
        isOnGround = false;
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    void Crouch()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x, 0.5f, this.transform.localScale.z);
        moveSpeed = 2f;
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, ground);

        if (Input.GetButtonDown("Jump") && isOnGround == true)
        {
            doJump();
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch();
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            moveSpeed = 5f;
        }

        if (isOnGround == true)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            playerController.Move(velocity * Time.deltaTime);
        }

        Vector3 move = transform.right * x + transform.forward * z;
        playerController.Move(move * moveSpeed * Time.deltaTime);
        
    }
}
