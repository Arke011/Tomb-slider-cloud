using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;
    [Range(0.01f, 0.99f)] public float smoothness;

    void Start()
    {
        // Find the player GameObject with the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Check if the player GameObject is found
        if (player != null)
        {
            // Get the Transform component of the player GameObject
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player not found! Make sure to tag your player GameObject with the 'Player' tag.");
        }
    }

    void LateUpdate()
    {
        // Check if the target is not null
        if (target != null)
        {
            // Move the camera smoothly towards the target position
            transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothness);
        }
    }
}
