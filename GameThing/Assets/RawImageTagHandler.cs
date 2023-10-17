using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RawImageTagHandler : MonoBehaviour
{
    public RawImage targetRawImage1; // Reference to the first target RawImage to activate.
    public RawImage targetRawImage2; // Reference to the second target RawImage to activate.
    public string requiredTag1 = "Tag1";
    public string requiredTag2 = "Tag2";

    public string dropZoneTag1 = "DropZone1";
    public string dropZoneTag2 = "DropZone2";

    private bool isCorrectDrop1 = false;
    private bool isCorrectDrop2 = false;

    private void Start()
    {
        targetRawImage1.gameObject.SetActive(false);
        targetRawImage2.gameObject.SetActive(false);
    }

    public void HandleDrop(string tag)
    {
        Debug.Log("Dropped: " + tag);

      
        if (gameObject.CompareTag(dropZoneTag1))
            {
                targetRawImage1.gameObject.SetActive(true); // Activate the target RawImage.
            }

        if (gameObject.CompareTag(dropZoneTag2))
        {
            targetRawImage2.gameObject.SetActive(true); // Activate the target RawImage.
        }
    }
}
