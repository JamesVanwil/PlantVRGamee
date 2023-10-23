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

    public void Start()
    {
        Seed.SetActive(false);
    }
    private void Update()
    {
        // Check if both objects are in the zone
        if (zoneCollider.bounds.Contains(object1Collider.bounds.center) &&
            zoneCollider.bounds.Contains(object2Collider.bounds.center))
        {
            // Trigger the animation
            Seed.SetActive(true);
            animator.SetTrigger("PlayAnimation");
        }
    }
}
