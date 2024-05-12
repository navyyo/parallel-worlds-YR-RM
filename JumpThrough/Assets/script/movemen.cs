using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class movemen : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = -9.81f;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    Vector3 velocity;
    bool isGrounded;
    private float jumpMultiplier =1f;
    public CharacterController controller;
   

    // Start is called before the first frame update

    void jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * jumpMultiplier);

            jumpMultiplier = 1f;
            Debug.Log("jumpppppp");
        }

    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            speed = 6f;
            velocity.y = -2f;
        }



        float x = Input.GetAxis("HorizontalP1");
        float z = Input.GetAxis("VerticalP1");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed *Time.deltaTime);
        jump();


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);






    }
}