using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public Text displayText;
    private bool playerInside = false;
    private bool textDisplayed = false;

    private void Start()
    {
        displayText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !textDisplayed)
        {
            playerInside = true;

            if (gameObject.CompareTag("Office"))
            {
                displayText.text = "You are now entering the office";
            }
            else if (gameObject.CompareTag("Exit"))
            {
                displayText.text = "You are now heading towards the exit";
            }
            if (gameObject.CompareTag("Incubators"))
            {
                displayText.text = "You are now entering the incubator area ";
            }
            if (gameObject.CompareTag("Kitchen"))
            {
                displayText.text = "You are now entering the kitchen";
            }
            if (gameObject.CompareTag("Seeds"))
            {
                displayText.text = "You are now entering the seed & flowers area";
            }


            displayText.gameObject.SetActive(true);
            StartCoroutine(HideTextAfterDelay(4f));
            textDisplayed = true;
        }
    }


    private IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        displayText.gameObject.SetActive(false);
        playerInside = false;
    }
}
