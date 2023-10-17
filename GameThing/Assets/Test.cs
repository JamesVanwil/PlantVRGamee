using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Test : MonoBehaviour
{
    public string requiredTag1 = "Tag1";
    public string requiredTag2 = "Tag2";
    public Text feedbackText;

    private bool isCorrectDrop1 = false;
    private bool isCorrectDrop2 = false;

    private void Start()
    {
        feedbackText.gameObject.SetActive(false);
    }

    public void HandleDrop(string tag)
    {
        if (tag == requiredTag1 && !isCorrectDrop1)
        {
            isCorrectDrop1 = true;
            feedbackText.text = "Correct: " + tag; // Set feedback text for the first correct item.
        }
        else if (tag == requiredTag2 && !isCorrectDrop2)
        {
            isCorrectDrop2 = true;
            feedbackText.text = "Correct: " + tag; // Set feedback text for the second correct item.
        }

        if (isCorrectDrop1 && isCorrectDrop2)
        {
            StartCoroutine(ShowFeedback("All Correct!", 3f));
        }
    }

    private IEnumerator ShowFeedback(string message, float duration)
    {
        feedbackText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        feedbackText.gameObject.SetActive(false);
    }
}
