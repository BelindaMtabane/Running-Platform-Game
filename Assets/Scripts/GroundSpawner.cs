using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTilePrefab; // Prefab for the ground tile
    Vector3 nextSpawnPosition; // Position to spawn the next ground tile

    public void SpawnTile ()
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
