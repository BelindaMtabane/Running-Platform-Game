using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner; // Reference to the GroundSpawner script
    //public GameObject rockPrefab;
    [SerializeField] GameObject obstaclePrefab; // Prefab for the obstacle
    //[SerializeField] private Obstacle obstacleScript; // Assign this in the Inspector
    Vector3 obstaclePositions; // Position to spawn the obstacle
   // [SerializeField] GameObject coinPrefab; // Prefab for the coin, {HealthCoin, SheinCoin, SpeedUpCoin, PointsCoin}
    public GameObject[] pickupPrefab;// Prefab for the pick up
    public GameObject healthPrefab;
    public GameObject coalPrefab;
    public GameObject pointsPrefab;
    public GameObject timeorbPrefab;

    public GameObject HandPrefab;
    public GameObject SpikePrefab;
    public GameObject portalPrefab;

    void Start()
    {
        groundSpawner = GameObject.FindAnyObjectByType<GroundSpawner>(); // Find the GroundSpawner script in the scene
        SpawnObstacle(); // Call the SpawnObstacle method to spawn an obstacle
        SpawnPickUps(); // Call the SpawnCoins method to spawn coins
    }

    private void OnTriggerExit(Collider other)
    {
        //GroundSpawner.SpawnTile(); // Call the SpawnTile method in the GroundSpawner script when the player exits the trigger
        Destroy(gameObject, 50); // Destroy the ground tile after 50 seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        /*
         * 
         * GameObject[] obstacles = { HandPrefab, SpikePrefab, portalPrefab};
         * int randomSpawnIndex = Random.Range(2, 5); // Randomly select a spawn index for the obstacle
        Transform spawnPoint = transform.GetChild(randomSpawnIndex).transform; // Get the spawn point from the child of the ground tile
        // Randomly choose an ObstacleType from the enum
        //Obstacle.ObstacleTypes randomObstacleType = (Obstacle.ObstacleTypes)Random.Range(0, System.Enum.GetValues(typeof(Obstacle.ObstacleTypes)).Length);

        // Instantiate the prefab directly using the selected ObstacleType
        //GameObject obstaclePrefab = obstacleScript.obstacleTypes[(int)randomObstacleType];
        //GameObject obstaclePrefabs = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform); // Instantiate the obstacle prefab at the spawn point
        GameObject temp = Instantiate(obstacles[selectedObstacle]);
        obstaclePositions = spawnPoint.position;/* // Set the obstacle position to the spawn point position*/
        GameObject[] obstacles = { HandPrefab, SpikePrefab, portalPrefab };
        int randomSpawnIndex = Random.Range(2, 5); // Randomly select a spawn index for the obstacle
        Transform spawnPoint = transform.GetChild(randomSpawnIndex).transform; // Get the spawn point from the child of the ground tile
        GameObject temp = Instantiate(obstacles[randomSpawnIndex]);
        obstaclePositions = spawnPoint.position; // Set the obstacle position to the spawn point position*/
    }

    void SpawnPickUps()
    {
        int pickupsToSpawn = 15; // Number of pickups to spawn
        GameObject[] pickups = { healthPrefab, coalPrefab, pointsPrefab, timeorbPrefab }; // Array of pickup prefabs

        for (int i = 0; i < pickupsToSpawn; i++)
        {
            int selectedPickUp = Random.Range(0, pickups.Length); // Randomly select a pickup prefab from the array
            GameObject temp = Instantiate(pickups[selectedPickUp]);
            temp.transform.position = GetRandomPickUpPointCollider(GetComponent<Collider>()); // Set the position of the pickup to a random point within the collider
            // Keep generating a new position if it's too close to the obstacle
            while (Vector3.Distance(temp.transform.position, obstaclePositions) < 1.0f)
            {
                temp.transform.position = GetRandomPickUpPointCollider(GetComponent<Collider>());// Check if the coin position is the same as the obstacle position
            }
            
        }
       
        /*int pickUpsToSpawn = Random.Range(1, 4); // Randomly select the number of coins to spawn
        for (int i = 0; i < pickUpsToSpawn; i++)
        {
            Vector3 pickUpPosition = GetRandomCoinPointCollider(GetComponent<Collider>());  // Set the position of the coin to a random point within the collider

            // Keep generating a new position if it's too close to the obstacle
            while (Vector3.Distance(pickUpPosition, obstaclePositions) < 1.0f)
            {
                pickUpPosition = GetRandomCoinPointCollider(GetComponent<Collider>());// Check if the coin position is the same as the obstacle position
            }

            // Random Y rotation but no rotation in X and Z
            Quaternion pickUpRotation = Quaternion.Euler(90, 0, 0);
            // Randomly choose one of the pickup prefabs
            GameObject selectedPrefab = pickupPrefab[Random.Range(0, pickupPrefab.Length)];
            GameObject temp = Instantiate(selectedPrefab, pickUpPosition, pickUpRotation, transform); // Spawn coin
            PickUpCoin pickUpScript = temp.GetComponent<PickUpCoin>();

            if (pickUpScript != null)
            {
                int typeCount = System.Enum.GetValues(typeof(PickUpCoin.PickUpType)).Length;
               // pickUpScript.pickUpType = (PickUpCoin.PickUpType)Random.Range(0, typeCount);
                //pickUpScript.pickUpType = pickUpType;// Set the pickup type
            }
        }*/
    }
    Vector3 GetRandomPickUpPointCollider (Collider collider)
    {
        Vector3 randomPoint = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        ); // Generate a random point within the bounds of the collider
        if (randomPoint != collider.ClosestPoint(randomPoint)){
            randomPoint = GetRandomPickUpPointCollider(collider); // Recursively call the method until a valid point is found
        }
        randomPoint.y = 1; // Set the Y coordinate to 1, matching it to the ground level
        return randomPoint;
    }
}
