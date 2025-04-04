using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    /*[SerializeField] GameObject groundTilePrefab; // Prefab for the ground tile
    [SerializeField] GameObject spawnGameWorldPrefab1; // Prefab for the spawn game world
    [SerializeField] GameObject spawnGameWorldPrefab2;
    [SerializeField] GameObject spawnGameWorldPrefab3;
    [SerializeField] GameObject repeatedSpawnGameWorldPrefab1;
    [SerializeField] GameObject repeatedSpawnGameWorldPrefab2;
    [SerializeField] GameObject repeatedSpawnGameWorldPrefab3;
    Vector3 nextSpawnPosition; // Position to spawn the next ground tile

    public void SpawnTile()
    {
        GameObject tempObj = Instantiate(groundTilePrefab, nextSpawnPosition, Quaternion.identity); // Instantiate the ground tile prefab
        nextSpawnPosition = tempObj.transform.GetChild(1).transform.position; // Update the next spawn position
    }
    public void SpawnGameWorld(GameObject spawnGameWorldPrefab)
    {
        GameObject newSegment = Instantiate(spawnGameWorldPrefab, nextSpawnPosition, Quaternion.identity); // Instantiate the ground tile prefab
        nextSpawnPosition = newSegment.transform.GetChild(1).transform.position; // Update the next spawn position
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        for (int i = 0; i < 11; i++) // Spawn 10 ground tiles
        {
            SpawnTile();// Spawn the ground first
        }

        SpawnGameWorld(spawnGameWorldPrefab1); // Call the SpawnTile method to spawn the first ground tile
        SpawnGameWorld(spawnGameWorldPrefab2); // Call the SpawnTile method to spawn the second ground tile
        SpawnGameWorld(spawnGameWorldPrefab3); // Call the SpawnTile method to spawn the third ground tile

        for (int j = 0; j < 3; j++) // Spawn 3 ground tiles
        {
            SpawnGameWorld(repeatedSpawnGameWorldPrefab1); // Call the SpawnTile method to spawn the repeated ground tile
            SpawnGameWorld(repeatedSpawnGameWorldPrefab2); // Call the SpawnTile method to spawn the repeated ground tile
            SpawnGameWorld(repeatedSpawnGameWorldPrefab3); // Call the SpawnTile method to spawn the repeated ground tile
        }
    }*/

    [SerializeField] GameObject groundTilePrefab; // Prefab for the ground tile
    Vector3 nextSpawnPosition; // Position to spawn the next ground tile

    public void SpawnTile()
    {
        GameObject tempObj = Instantiate(groundTilePrefab, nextSpawnPosition, Quaternion.identity); // Instantiate the ground tile prefab
        nextSpawnPosition = tempObj.transform.GetChild(1).transform.position; // Update the next spawn position
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++) // Spawn 10 ground tiles
        {
            SpawnTile();
        }
    }
}
