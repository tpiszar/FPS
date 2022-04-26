using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10.0f;
    public Vector3 velocity;
    public CharacterController controller;
    public Vector3 impact;
    public float jumpHeight = 1.0f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        float speed;
        if (Input.GetButton("Crouch"))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        movement = movement * speed * Time.deltaTime;

        controller.Move(movement);

        if (Input.GetButtonDown("Jump") && isGrounded) //controller.isGrounded
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (impact.magnitude > 0.2)
        {
            controller.Move(impact * Time.deltaTime);
            impact = Vector3.Lerp(impact, Vector3.zero, 10 * Time.deltaTime);
        }
    }
}