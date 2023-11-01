using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DropZones : MonoBehaviour, IDropHandler
{
    public GameObject correctImage;
    public GameObject wrongImage;
    public GameObject correctNewImage;

    private Coroutine hideImageCoroutine;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableImages draggable = eventData.pointerDrag.GetComponent<DraggableImages>();
        if (draggable != null)
        {
            if (draggable.gameObject == correctImage)
            {
                draggable.enabled = false;
                correctNewImage.SetActive(true);
            }
            else
            {
                wrongImage.SetActive(true);

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
