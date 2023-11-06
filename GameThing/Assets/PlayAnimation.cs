using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator glassAnimation;
    public Transform zoneTransform; // Reference to the zone's transform
    private bool open;

    public GameObject seed; // Reference to the seed object
    public GameObject flower; // Reference to the flower object

    public GameObject seed2; // Reference to the seed object
    public GameObject flower2; // Reference to the flower object

    public GameObject seed3; // Reference to the seed object
    public GameObject flower3; // Reference to the flower object

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
        StartCoroutine(DeactivateSeedAndActivateFlower());
        StartCoroutine(DeactivateSeedAndActivateFlower2());
        StartCoroutine(DeactivateSeedAndActivateFlower3());
    }

    private IEnumerator DeactivateSeedAndActivateFlower()
    {
        // Wait for the close animation to finish
        yield return new WaitForSeconds(glassAnimation.GetCurrentAnimatorStateInfo(0).length);

        // Calculate the distance between the seed and the zone
        float distance = Vector3.Distance(seed.transform.position, zoneTransform.position);
        float thresholdDistance = 1.0f; // Adjust this value as needed

        if (distance < thresholdDistance)
        {
            // Deactivate the seed's renderer and collider
            Renderer seedRenderer = seed.GetComponent<Renderer>();
            Collider seedCollider = seed.GetComponent<Collider>();

            seedRenderer.enabled = false;
            seedCollider.enabled = false;

            // Activate the corresponding flower
            flower.SetActive(true);
        }

    }

    private IEnumerator DeactivateSeedAndActivateFlower2()
    {
        // Wait for the close animation to finish
        yield return new WaitForSeconds(glassAnimation.GetCurrentAnimatorStateInfo(0).length);

        // Calculate the distance between the seed and the zone
        float distance = Vector3.Distance(seed2.transform.position, zoneTransform.position);
        float thresholdDistance = 1.0f; // Adjust this value as needed

        if (distance < thresholdDistance)
        {
            // Deactivate the seed's renderer and collider
            Renderer seedRenderer = seed2.GetComponent<Renderer>();
            Collider seedCollider = seed2.GetComponent<Collider>();

            seedRenderer.enabled = false;
            seedCollider.enabled = false;

            // Activate the corresponding flower
            flower2.SetActive(true);
        }

    }

    private IEnumerator DeactivateSeedAndActivateFlower3()
    {
        // Wait for the close animation to finish
        yield return new WaitForSeconds(glassAnimation.GetCurrentAnimatorStateInfo(0).length);

        // Calculate the distance between the seed and the zone
        float distance = Vector3.Distance(seed3.transform.position, zoneTransform.position);
        float thresholdDistance = 1.0f; // Adjust this value as needed

        if (distance < thresholdDistance)
        {
            // Deactivate the seed's renderer and collider
            Renderer seedRenderer = seed3.GetComponent<Renderer>();
            Collider seedCollider = seed3.GetComponent<Collider>();

            seedRenderer.enabled = false;
            seedCollider.enabled = false;

            // Activate the corresponding flower
            flower3.SetActive(true);
        }

    }
}
