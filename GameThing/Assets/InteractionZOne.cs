using UnityEngine;
using System.Collections;

public class InteractionZOne : MonoBehaviour
{
    public GameObject textPopup;
    public Animator animator1;
    public Animator animator2;

    private bool inZone = false;

    void Start()
    {
        textPopup.SetActive(false);
    }

    void Update()
    {
        if (inZone)
        {
            textPopup.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                // Trigger the first animation
                animator1.SetTrigger("AnimationTrigger");

                // Trigger the second animation with a delay
                StartCoroutine(PlaySecondAnimation());
            }
        }
        else
        {
            textPopup.SetActive(false);
        }
    }

    IEnumerator PlaySecondAnimation()
    {
        yield return new WaitForSeconds(1.0f); // Adjust the delay as needed
        animator2.SetTrigger("AnimationTrigger");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Adjust the tag as needed
        {
            inZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Adjust the tag as needed
        {
            inZone = false;
        }
    }
}

