using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedFusion : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public Collider object1Collider; // Reference to the first object's collider
    public Collider object2Collider; // Reference to the second object's collider
    public Collider zoneCollider; // Reference to the zone's collider
    public GameObject Seed;

    public GameObject object1; // Reference to the first object
    public GameObject object2; // Reference to the second object

    public Transform teleportTarget; // Reference to the TeleportTarget GameObject

    private bool objectsCombined = false;

    public GameObject Player;

    public void Start()
    {
        Seed.SetActive(false);
    }

    private void Update()
    {
        if (!objectsCombined)
        {
            // Check if both objects are in the zone
            if (zoneCollider.bounds.Contains(object1Collider.bounds.center) &&
                zoneCollider.bounds.Contains(object2Collider.bounds.center))
            {
                // Deactivate or destroy the objects
                object1.SetActive(false);
                object2.SetActive(false);

                // Teleport the player to the TeleportTarget position
                TeleportPlayerToDestination();

                // Trigger the animation
                Seed.SetActive(true);
                animator.SetTrigger("PlayAnimation");

                objectsCombined = true;
            }
        }
    }

    private void TeleportPlayerToDestination()
    {
        if (teleportTarget != null)
        {
            // Set the player's position to the teleport destination's position
            Player.transform.position = teleportTarget.position;

            // Reset the player's velocity if it has a Rigidbody
            Rigidbody playerRigidbody = Player.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;
            }
        }
    }

}
