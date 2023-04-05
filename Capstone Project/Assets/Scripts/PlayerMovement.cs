using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -19f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    Vector3 spawnPoint;

    public bool isSprinting = false;
    public float sprintingMultiplier;

    public bool isCrouching = false;
    public float standingHeight = 3.8f;
    public float crouchingMultiplier;

    public float crouchingHeight = 2.5f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spawnPoint = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded &&velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;


        controller.Move(move * speed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        Vector3 movement = new Vector3();

        movement = x * transform.right + z * transform.forward;

        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = true;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            isCrouching = false;
        }

        if (isCrouching == true)
        {
            controller.height = crouchingHeight;
            //movement *= crouchingMultiplier;
            speed = 2f;
        }
        else
        {
            controller.height = standingHeight;
            speed = 5f;
        }

        if (isSprinting == true)
        {
            movement *= sprintingMultiplier;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(movement * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);


         if(gameObject.transform.position.y < -20f)
        {
            gameObject.transform.position = spawnPoint;
        }

        if (movement!= Vector3.zero)
        {



        }


    }

}
