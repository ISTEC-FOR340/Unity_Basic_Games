using UnityEngine;
using System.Collections.Generic;

public partial class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")]
    public GameObject enemyPrefab;
    public Transform startPlane;
    public GameObject player;

    [Header("Game State")]
    public int enemyCount = 0;
    public float spawnRange = 15f;

    private List<GameObject> activeEnemies = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    public void LevelComplete()
    {
        enemyCount++;
        RestartGame();
    }

    public void PlayerHit()
    {
        if (enemyCount > 0) enemyCount--;
        RestartGame();
    }

    void RestartGame()
    {
        // 1. Move Player back to start
        player.transform.position = new Vector3(startPlane.position.x, player.transform.position.y, startPlane.position.z);

        // 2. Clear old enemies
        foreach (GameObject enemy in activeEnemies)
        {
            Destroy(enemy);
        }
        activeEnemies.Clear();

        // 3. Spawn new enemies based on updated count
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                0.5f,
                Random.Range(-spawnRange, spawnRange)
            );

            GameObject newEnemy = Instantiate(enemyPrefab, randomPos, Quaternion.identity);
            activeEnemies.Add(newEnemy);
        }
    }
}