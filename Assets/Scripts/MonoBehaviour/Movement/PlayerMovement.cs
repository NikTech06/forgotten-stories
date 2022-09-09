using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float weight = 10;
    public float jumpHeight = 3f;
    public float sprint = 2;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetButton("Sprint"))
        {
            speed = speed * sprint;
        }

        controller.Move(move * speed * Time.deltaTime * sprint);

        if (Input.GetButton("Sprint"))
        {
            speed = speed / sprint;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * weight / 4 * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime * weight / 4;

        controller.Move(velocity * Time.deltaTime);
    }
}