using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;//Associate with the player
    PlayerMovement playerMovement;// Call the Player movement class
    [SerializeField] GameObject deathMenu; // Reference to the Death Menu (assigned in the Inspector)
    private Rigidbody playerRigid;//This will be attached to the Player to allow gravity to interact on the Player's physics

    void Start()
    {
        playerRigid = thePlayer.GetComponent<Rigidbody>();//This will control the Player's position in the game
        deathMenu.SetActive(false);// This will make the death menu disappear
    }
    void OnCollisionEnter(Collision collision)
    {
        // Log the name of the object the player is colliding with
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        
        // Check if the the death menu is null to make it active or create a debug message
        if (deathMenu != null)
        {
            // Update the Death Menu score
            Time.timeScale = 0; // Freezes game
            deathMenu.SetActive(true); // This makes the death menu appear
        }
        else
        {
            Debug.LogError("Death Menu is not assigned!");// This will display an error message
        }
    }
}
