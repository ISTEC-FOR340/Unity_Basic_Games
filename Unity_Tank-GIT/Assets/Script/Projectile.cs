using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 3f;

    void Start()
    {
        // Destroy the bullet automatically after 'lifeTime' seconds
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the bullet forward every frame
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}