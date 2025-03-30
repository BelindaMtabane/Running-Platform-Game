using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    PlayerMovement playerMovement; // Reference to the PlayerMovement script
    [SerializeField] int increasePoints = 10; // Points to increase when the coin is collected
    [SerializeField] int increaseHealth = 10; // Health to increase when the coin is collected
    [SerializeField] int increaseShield = 10; // Shield to increase when the coin is collected
    [SerializeField] int slowDownTimeForSeconds = 5; // Time to slow down the player when the coin is collected
    public enum PickUpType
    {
        Health,
        Shield,
        TimeOrb,
        Points
    }

    public PickUpType pickUpType; // Type of the pickup
    private Renderer coinRenderer; // Renderer component of the coin
    [SerializeField] float turnSpeed = 90f; // Speed at which the coin rotates

    void OnTriggerEnter(Collider other)
    {  
        if (other.gameObject.GetComponent<Obstacle>() != null){
            Destroy(gameObject); // Check if the object that entered the trigger is an obstacle, so we destroy the coin
            return; // Exit the method if the object is an obstacle
        };

        if (other.gameObject.name != "Player") return; // Check if the object that entered the trigger is the player

        switch (pickUpType)
        {
            case PickUpType.Health:
                // Add health to the player
                playerMovement.AddHealth(increaseHealth); // Call the AddHealth method in the PlayerMovement script
                break;
            case PickUpType.Shield:
                // Add shield to the player
                playerMovement.AddShield(increaseShield); // Call the AddShield method in the PlayerMovement script
                break;
            case PickUpType.TimeOrb:
                // Add time to the player
                playerMovement.AddTimeOrb(slowDownTimeForSeconds); // Call the AddTimeOrb method in the PlayerMovement script
                break;
            case PickUpType.Points:
                // Add points to the player
                playerMovement.AddPoints(increasePoints); // Call the AddPoints method in the PlayerMovement script
                break;
        }

        // Update the UI text
        playerMovement.UpdateUI();

        Destroy(gameObject); // Destroy the coin object
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GameObject.FindAnyObjectByType<PlayerMovement>(); // Find the PlayerMovement script in the scene

        coinRenderer = GetComponent<Renderer>();
        if (coinRenderer != null)
        {
            switch (pickUpType)
            {
                case PickUpType.Health:
                    coinRenderer.material.color = Color.green;
                    break;
                case PickUpType.Shield:
                    coinRenderer.material.color = Color.blue;
                    break;
                case PickUpType.TimeOrb:
                    coinRenderer.material.color = Color.black;
                    break;
                case PickUpType.Points:
                    coinRenderer.material.color = Color.yellow;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime); // Rotate the coin around its Y-axis
    }
}
