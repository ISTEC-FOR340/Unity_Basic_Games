using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform player;

    void Start()
    {
        // Find the player cube by tag (make sure your Cube is tagged "Player")
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate direction toward the player on the XZ plane
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0; // Keep movement strictly on the 2D plane

            // Move toward the player
            transform.position += direction * speed * Time.deltaTime;

            // Optional: Make the sphere "look" at the player
            transform.forward = direction;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            // We don't use GameManager here because we only want to 
            // reduce enemies when the PLAYER is hit, not when a bullet hits an enemy.
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            // The tank hit an enemy!
            GameManager.Instance.PlayerHit();
        }
    }
}