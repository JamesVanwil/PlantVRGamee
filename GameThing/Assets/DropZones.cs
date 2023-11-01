using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DropZones : MonoBehaviour, IDropHandler
{
    public GameObject correctCube;
    public GameObject wrongCube;
    public GameObject correctNewCube;

    private Coroutine hideCubeCoroutine;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableImages draggable = eventData.pointerDrag.GetComponent<DraggableImages>();
        if (draggable != null)
        {
            if (draggable.CompareTag("CorrectCubeTag"))
            {
                draggable.enabled = false;
                correctCube.SetActive(false);
                correctNewCube.SetActive(true);
            }
            else if (draggable.CompareTag("WrongCubeTag"))
            {
                wrongCube.SetActive(true);
                // Reset the cube's position
                draggable.ResetPosition(); // Implement this function in DraggableCubes script
                if (hideCubeCoroutine != null)
                {
                    StopCoroutine(hideCubeCoroutine);
                }
                hideCubeCoroutine = StartCoroutine(HideCubeAfterDelay(wrongCube, 2f));
            }
        }
    }

    private IEnumerator HideCubeAfterDelay(GameObject cubeToHide, float delay)
    {
        yield return new WaitForSeconds(delay);
        cubeToHide.SetActive(false);
    }
}
