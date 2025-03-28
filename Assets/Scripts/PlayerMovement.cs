using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Declare Variables
    public float playerSpeed = 4.0f;//This is a variable that determines the velocity for the player
    public float playerMovement = 5.0f;//Track the player movements
    public float rightMaximum = 4.02f;
    public float leftMaximum = -4.02f;
    public float jumpingForce = 10.0f;//This is a variable that determines the force of the jump
    private Rigidbody rigid;//This will be attached to the Player to allow gravity to interact on the Player's physics
    private bool IsGrounded = true;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();//This will control the PLayer's position in the game
    }
    // Update is called once per frame
    void Update()
    {
        //Move the Player's position using transform in a certain direction, using the vector
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        //Create an if statement to check if the keys or arrow keys are pressed to move the Player in the x axis
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Create another if stament to track the movement of the player does not go over the platform
            if (this.gameObject.transform.position.x > leftMaximum)
            {
                //Move the Player left
                transform.Translate(Vector3.left * Time.deltaTime * playerMovement);
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Create another if stament to track the movement of the player does not go over the platform
            if (this.gameObject.transform.position.x < rightMaximum)
            {
                //Move the Player right
                transform.Translate(Vector3.right * Time.deltaTime * playerMovement);
            }
        }
        else if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            // Add force to make the player jump
            rigid.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
            IsGrounded = false; // Set isGrounded to false when the player jumps
            //rigid.useGravity = true;
        }
    }

    // Detect collisions and check if the player is grounded
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Check if the player is colliding with the ground
        {
            IsGrounded = true; //Reset when touching any surface
            //rigid.useGravity = false; // Re-enable gravity to make the player not fall when not jumping
        }
    }
}
