using UnityEngine;
using UnityEngine.UI; // Import the UI namespace to use UI elements
using UnityEngine.SceneManagement; // Import the SceneManagement namespace to manage scenes
using System.Collections;
using TMPro; // Import the Collections namespace for IEnumerator

public class PlayerMovement: MonoBehaviour
{
    bool isAlive = true; // This is a flag to check if the player is alive
    [SerializeField] float speed = 5f; // This is the speed of the player
    [SerializeField] Rigidbody rigidbody; // Reference to the Rigidbody component

    private int points = 0; // This is the score of the player
    private int health = 100; // This is the health of the player
    [SerializeField] int maxHealth = 100; // This is the maximum health of the player
    private int shield = 0; // This is the shield of the player
    [SerializeField] int maxShield = 100; // This is the maximum shield of the player
    private int timeOrb = 0; // This is the time orb of the player
    [SerializeField] int maxTimeOrb = 10; // This is the maximum time orb of the player

    float horizontalInput;
    [SerializeField] float horizontalSpeedMultiplier = 1.5f; // Multiplier for horizontal speed

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI shieldText;

    private void FixedUpdate()
    {
        if (!isAlive) return; // If the player is not alive, do not move

        Vector3 forwardMovement = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMovement = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalSpeedMultiplier;
        rigidbody.MovePosition(rigidbody.position + forwardMovement + horizontalMovement);
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5) // Check if the player falls below a certain height
        {
            KillPlayer(); // Call the KillPlayer method
        }
        
        // Quite the game if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape)) // Check if the Escape key is pressed
        {
            Application.Quit(); // Quit the application
        }
    }


    public void KillPlayer()
    {
        // This is method is currently not being used, it will be used when the player collides with a certain object
        isAlive = false; // Set the player to not alive
        // Restart the Game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd; // Add points to the player's score
    }

    public void AddHealth(int healthToAdd)
    {
        health += healthToAdd; // Add health to the player's health
        if (health > maxHealth) // Ensure health does not exceed maxHealth
        {
            health = maxHealth;
        }
    }

    public void AddShield(int shieldToAdd)
    {
        shield += shieldToAdd; // Add shield to the player's shield
        if (shield > maxShield) // Ensure shield does not exceed maxShield
        {
            shield = maxShield;
        }
    }

    public void AddTimeOrb(int timeOrbToAdd)
    {
        timeOrb += timeOrbToAdd; // Add time orb to the player's time orb
        if (timeOrb > maxTimeOrb) // Ensure timeOrb does not exceed maxTimeOrb
        {
            timeOrb = maxTimeOrb;
        }
        StartCoroutine(SlowDownPlayer(timeOrbToAdd)); // Trigger the slowdown effect
    }

    private IEnumerator SlowDownPlayer(int duration)
    {
        float originalSpeed = speed; // Store the original speed
        speed = 2f; // Reduce the player's speed
        yield return new WaitForSeconds(duration); // Wait for the specified duration
        speed = originalSpeed; // Revert to the original speed
    }


    public void UpdateUI()
    {
        scoreText.text = "Score: " + points; // Update the score text
        healthText.text = "Health: " + health; // Update the health text
        shieldText.text = "Shield: " + shield; // Update the shield text
    }
}
