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

    private bool objectsCombined = false;

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
                object1.SetActive(false); // Deactivate the first object
                object2.SetActive(false); // Deactivate the second object

                // Trigger the animation
                Seed.SetActive(true);
                animator.SetTrigger("PlayAnimation");

                objectsCombined = true; // Mark that the objects have been combined
            }
        }
    }
}