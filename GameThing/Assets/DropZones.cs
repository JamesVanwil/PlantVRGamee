using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DropZones : MonoBehaviour, IDropHandler
{
    public GameObject correctImage;
    public GameObject wrongImage;
    public GameObject correctNewImage; // New image for the correct drop.

    private Coroutine hideImageCoroutine;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableImages draggable = eventData.pointerDrag.GetComponent<DraggableImages>();
        if (draggable != null)
        {
            if (draggable.gameObject == correctImage)
            {
                // The correct image has been dropped.
                // Lock the image in place (if necessary).
                draggable.enabled = false;

                // Show the correct new image.
                correctNewImage.SetActive(true);
            }
            else
            {
                // A wrong image has been dropped.
                // Show the wrong image.
                wrongImage.SetActive(true);

                // Start a coroutine to hide the wrong image after 2 seconds.
                if (hideImageCoroutine != null)
                {
                    StopCoroutine(hideImageCoroutine);
                }
                hideImageCoroutine = StartCoroutine(HideImageAfterDelay(wrongImage, 2f));
            }
        }
    }

    private IEnumerator HideImageAfterDelay(GameObject imageToHide, float delay)
    {
        yield return new WaitForSeconds(delay);
        imageToHide.SetActive(false);
    }
}
