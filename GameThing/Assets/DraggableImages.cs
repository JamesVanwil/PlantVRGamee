using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableImages : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 startPosition;
    private Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Record the starting position and parent.
        startPosition = transform.position;
        startParent = transform.parent;

        // Change the parent to allow dragging over other elements.
        transform.SetParent(transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Update the image position to follow the pointer's position.
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Restore the parent and position to their original values.
        transform.SetParent(startParent);
        transform.position = startPosition;
    }
}
