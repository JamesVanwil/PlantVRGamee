using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageDragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RawImage rawImage; // Reference to the RawImage component.

    private void Start()
    {
        // Get references to the components we'll use.
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        rawImage = GetComponent<RawImage>(); // Get the reference to the RawImage component.
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Called when the user clicks on the image.
        // You can add any specific behavior here.
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Called when the user starts dragging the image.
        canvasGroup.alpha = 0.6f; // Make the image slightly transparent while dragging.
        canvasGroup.blocksRaycasts = false; // Allow interaction with objects behind the image.
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Called as the user drags the image.
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Called when the user releases the image.
      
        
            canvasGroup.alpha = 1f; // Restore the image's full opacity.
            canvasGroup.blocksRaycasts = true; // Restore interaction with other objects.
        
        // Pass the tag of the RawImage as a parameter to the HandleDrop method in the RawImageTagHandler script.
        RawImageTagHandler tagHandler = GetComponent<RawImageTagHandler>();
        
    }
}
