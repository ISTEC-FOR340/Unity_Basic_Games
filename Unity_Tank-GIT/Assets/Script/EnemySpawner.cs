using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 5; // Your 'x' variable
    public float spawnRange = 20f;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Pick a random spot on the plane
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                0.5f, // Height of the sphere
                Random.Range(-spawnRange, spawnRange)
            );

            Instantiate(enemyPrefab, randomPos, Quaternion.identity);
        }
    }
}