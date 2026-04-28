using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [Header("Settings")]
    public GameObject bulletPrefab; // Drag your bullet prefab here
    public Transform firePoint;     // Drag an Empty Object placed at the cube's front
    public float fireRate = 0.5f;   // Seconds between shots

    private float nextFireTime = 0f;

    void Update()
    {
        // Check for Left Mouse Button click and if enough time has passed
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Create a copy of the bullet at the firePoint's position and rotation
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
