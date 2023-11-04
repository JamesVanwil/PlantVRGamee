using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeedFusion : MonoBehaviour
{
    public Collider object1Collider;
    public Collider object2Collider;
    public Collider zoneCollider;
    public GameObject Seed;
    public GameObject object1;
    public GameObject object2;

    private bool objectsCombined = false;

    public Transform teleportTarget;
    public GameObject Player;

    public void Start()
    {
        Seed.SetActive(false);
    }

    private void Update()
    {
        if (!objectsCombined)
        {
            if (zoneCollider.bounds.Contains(object1Collider.bounds.center) &&
                zoneCollider.bounds.Contains(object2Collider.bounds.center))
            {
                // Deactivate or destroy the objects (object1 and object2)
                object1.SetActive(false);
                object2.SetActive(false);

                // Teleport the player to the TeleportTarget position
                TeleportPlayerToDestination();

                // Trigger the animation
                Seed.SetActive(true);

                objectsCombined = true;
            }
        }
    }

    private void TeleportPlayerToDestination()
    {
        Player.transform.position = teleportTarget.transform.position;
    }
}
