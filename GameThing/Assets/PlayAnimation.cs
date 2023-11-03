using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator glassAnimation;
    public GameObject object1; // Reference to the first object
    public GameObject Flower; // Reference to the flower object
    public Transform zoneTransform; // Reference to the zone's transform
    private bool open;

    public void Start()
    {
        glassAnimation.SetBool("Open", false);
        glassAnimation.SetBool("Close", false);
        open = false;
    }

    public void OpenAnim()
    {
        open = true;
        glassAnimation.SetBool("Open", true);
        glassAnimation.SetBool("Close", false);
    }

    public void CloseAnim()
    {
        glassAnimation.SetBool("Open", false);
        glassAnimation.SetBool("Close", true);
        open = false;
        StartCoroutine(DeactivateObject1AndActivateFlower());
    }

    private IEnumerator DeactivateObject1AndActivateFlower()
    {
        // Wait for the close animation to finish
        yield return new WaitForSeconds(glassAnimation.GetCurrentAnimatorStateInfo(0).length);

        // Calculate the distance between the object and the zone
        float distance = Vector3.Distance(object1.transform.position, zoneTransform.position);

        // Define a threshold distance for the object to disappear and the flower to appear
        float thresholdDistance = 1.0f; // Adjust this value as needed

        if (distance < thresholdDistance)
        {
            // Deactivate the first object's renderer and collider
            Renderer object1Renderer = object1.GetComponent<Renderer>();
            Collider object1Collider = object1.GetComponent<Collider>();

            object1Renderer.enabled = false;
            object1Collider.enabled = false;

            Flower.SetActive(true);
        }
    }
}
