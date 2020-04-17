using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController con;
    public Transform camera;

    public float yMove = -9.81f;
    public float MoveSpeed = 0.05f;
    float TurningSpeed = 360f;

    Vector3 movement = Vector3.zero;

    public bool isPlayerJumping = false;
    
    void Start()
    {
        con = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void MovePlayer()// Moving
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        if (zMove != 0)//Forward:Backward
        {
            movement += this.transform.forward * zMove * MoveSpeed * Time.deltaTime;
        }
        if (xMove != 0)//Right:Left
        {
            movement += this.transform.right * xMove * MoveSpeed * Time.deltaTime;
        }

        con.Move(movement);
    }

    void TurnPlayer()// Turning
    {
        Vector3 currentRotation = this.transform.eulerAngles;

        if (Input.GetAxis("Mouse X") > 0)
        {
            currentRotation.y += TurningSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            currentRotation.y -= TurningSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            currentRotation.x += Mathf.Clamp(TurningSpeed * 0.5f * Time.deltaTime, -90, 90);
        }
        else if (Input.GetAxis("Mouse Y") > 0)
        {
            currentRotation.x -= Mathf.Clamp(TurningSpeed * 0.5f * Time.deltaTime, -90, 90);
        }

        this.transform.eulerAngles = currentRotation;
    }

    void Update()
    {
        MovePlayer();
        TurnPlayer();
    }
}
