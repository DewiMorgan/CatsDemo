using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Player controller via https://www.youtube.com/watch?v=_QajrabyTJc&ab_channel=Brackeys
 */
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        velocity.y -= 20f;
    }

    // Update is called once per frame
    void Update()
    {
        // Walking.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Jumping, Falling
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded) {
            if (velocity.y < 0) { // Hit the ground.
                velocity.y = -2f; // Tiny bit of -v anyway.
            }
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Space")) { // Jumping.
                // Initial velocity = sqrt (jump height * -2 * gravity)
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // Multiply by Time twice, as gravity is acceleration.
    }
}
