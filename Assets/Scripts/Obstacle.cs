using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;//Associate with the player
    //public GameObject[] obstacleTypes;
    //[SerializeField] private Obstacle obstacleScript; // Reference to the Obstacle script
   // PlayerMovement playerMovement;// Call the Player movement class
    [SerializeField] GameObject deathMenu; // Reference to the Death Menu (assigned in the Inspector)
    [SerializeField] TMP_Text ObstacleCollision;
    //[SerializeField] GameObject woodenSpikes; // Reference to the Wooden Spike (assigned in the Inspector)
    //[SerializeField] GameObject portalGates; // Reference to the Evil Hands (assigned in the Inspector)
    //private Rigidbody playerRigid;//This will be attached to the Player to allow gravity to interact on the Player's physics
    //public EvilHands evilHands; // Reference to the EvilHands script
    //private WoodenSpike woodenSpike; // Reference to the WoodenSpike script
    //private PortalGateWay portalGateWay; // Reference to the PortalGateWay script
    void Start()
    {
    }
    public void EnableMenu()
    {
        deathMenu.SetActive(true);// This will make the death menu appear
    }
    /*public enum ObstacleTypes
    {
        PortalGateway,
        Spike,
    }
    void Update()
    {
        //evilHands.EvilHandMovement(); // Call the EvilHandMovement method
        woodenSpike.WoodenSpikeMovement(); // Call the Update method of the WoodenSpike script
    }*/
    void OnCollisionEnter(Collision collision)
    {
        // Log the name of the object the player is colliding with
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        // Check if the player collides with the Spike or EvilHands

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Check if the the death menu is null to make it active or create a debug message
            if (deathMenu != null)
            {
                Debug.Log("Death Menu is assigned!");
                // Update the Death Menu score
                Time.timeScale = 0; // Freezes game
                                    //deathMenu.SetActive(true); // This makes the death menu appear

                EnableMenu(); // Call the EnableMenu method to show the death menu
                // Update the UI text
                ObstacleCollision.text = "You have been killed by " + collision.gameObject.name; // Update the UI text with the name of the object
            }
            else
            {
                Debug.LogError("Death Menu is not assigned!");// This will display an error message
            }
        }
    }
}
