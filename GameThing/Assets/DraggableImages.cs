using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableImages : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform startParent;
    private Rigidbody rb;

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

    public void ResetPosition()
    {
        // Reset the cube's position to its initial position.
        transform.position = startPosition;

        // You may also want to reset its velocity and angular velocity to prevent any ongoing physics motion.
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
