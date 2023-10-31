using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableImages : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(transform.parent.parent);
        // You should comment out or remove this line to keep the image visible while dragging.
        // GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(startParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = startPosition;
    }
}
