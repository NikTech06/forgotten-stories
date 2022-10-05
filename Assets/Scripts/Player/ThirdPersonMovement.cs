using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float verticalSpeed = 1f;
    public float rotationSpeed = 10f;
    public float gravity = -9.81f;
    public float groundDistance = 0.03f;
    public float jumpHeight = 3f;

    public Transform groundCheck;

    public LayerMask groundMask;

    Vector3 velocity;

    [HideInInspector]
    public bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
		{
            velocity.y = -2f;
		}

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float move = Mathf.Clamp(Mathf.Abs(horizontal) + vertical * verticalSpeed, -1, 1);

        Vector3 rotation = transform.rotation * Vector3.forward;
        controller.Move(rotation.normalized * move * speed * Time.deltaTime);

        transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
		{
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
