using UnityEngine;

public class CubeController : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 5f;
    public float rotationSensitivity = 2f;

    private float rotationY = 0f;

    void Start()
    {
        // Keeps the mouse from wandering off screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. Handle Rotation (Horizontal only)
        float mouseX = Input.GetAxis("Mouse X") * rotationSensitivity;
        rotationY += mouseX;

        // Apply rotation only on the Y axis to keep it on the plane
        transform.localRotation = Quaternion.Euler(0f, rotationY, 0f);

        // 2. Handle Movement (XZ Plane)
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Calculate direction relative to where the cube is facing
        // transform.forward and transform.right are automatically constrained to the plane
        // because we only allow the cube to rotate around the Y axis.
        Vector3 move = (transform.forward * moveZ) + (transform.right * moveX);

        // Apply movement
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}