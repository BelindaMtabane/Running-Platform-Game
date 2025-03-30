using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner; // Reference to the GroundSpawner script
    [SerializeField] GameObject obstaclePrefab; // Prefab for the obstacle

    [SerializeField] GameObject coinPrefab; // Prefab for the coin, {HealthCoin, SheinCoin, SpeedUpCoin, PointsCoin}

    void Start()
    {
        groundSpawner = GameObject.FindAnyObjectByType<GroundSpawner>(); // Find the GroundSpawner script in the scene
        SpawnObstacle(); // Call the SpawnObstacle method to spawn an obstacle
        SpawnCoins(); // Call the SpawnCoins method to spawn coins
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(); // Call the SpawnTile method in the GroundSpawner script when the player exits the trigger
        Destroy(gameObject, 2); // Destroy the ground tile after 2 seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle ()
    {
        int randomSpawnIndex = Random.Range(2, 5); // Randomly select a spawn index for the obstacle
        Transform spawnPoint = transform.GetChild(randomSpawnIndex).transform; // Get the spawn point from the child of the ground tile
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform); // Instantiate the obstacle prefab at the spawn point
    }

    void SpawnCoins () {
        int coinsToSpawn = Random.Range(1, 4); // Randomly select the number of coins to spawn
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform); // Instantiate the coin prefab
            temp.transform.position = GetRandomCoinPointCollider(GetComponent<Collider>()); // Set the position of the coin to a random point within the collider
            PickUpCoin coinScript = temp.GetComponent<PickUpCoin>();
            if (coinScript != null) {
                int typeCount = System.Enum.GetValues(typeof(PickUpCoin.PickUpType)).Length;
                coinScript.pickUpType = (PickUpCoin.PickUpType)Random.Range(0, typeCount);
            }
        }
    }

    Vector3 GetRandomCoinPointCollider (Collider collider)
    {
        Vector3 randomPoint = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        ); // Generate a random point within the bounds of the collider
        if (randomPoint != collider.ClosestPoint(randomPoint)){
            randomPoint = GetRandomCoinPointCollider(collider); // Recursively call the method until a valid point is found
        }
        randomPoint.y = 1; // Set the Y coordinate to 1, matching it to the ground level
        return randomPoint;
    }
}
