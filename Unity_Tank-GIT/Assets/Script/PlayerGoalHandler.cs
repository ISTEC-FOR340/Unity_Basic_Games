using UnityEngine;

public class PlayerGoalHandler : MonoBehaviour
{
    [Header("Area References")]
    public Transform startPlane;
    public string finishTag = "Finish";

    private Vector3 spawnPoint;

    void Start()
    {
        // Set the spawn point to the center of the Start plane
        // We add a small Y offset so the cube doesn't get stuck in the floor
        if (startPlane != null)
        {
            spawnPoint = new Vector3(startPlane.position.x, transform.position.y, startPlane.position.z);
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        transform.position = spawnPoint;

        // Optional: Reset momentum if you are using physics
        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If we touch an object tagged "Finish", go back to the start
        if (other.CompareTag(finishTag))
        {
            Debug.Log("Goal Reached! Resetting...");
            ResetPosition();
        }
    }
}