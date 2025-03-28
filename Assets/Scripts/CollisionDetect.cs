using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;//Associate with the player
    private Rigidbody playerRigid;//This will be attached to the Player to allow gravity to interact on the Player's physics

    void Start()
    {
        playerRigid = thePlayer.GetComponent<Rigidbody>();//This will control the Player's position in the game
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            thePlayer.GetComponent<PlayerMovement>().enabled = false;//Apply for the player to not move through the obstacle
            
            playerRigid.AddForce(Vector3.up * 8.0f, ForceMode.Impulse);// Apply force for bounce
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            thePlayer.GetComponent<PlayerMovement>().enabled = true;//Apply the player's movement mechanics after stoops interecating with the obstacle
        }
    }

}
