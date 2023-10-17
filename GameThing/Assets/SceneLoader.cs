using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;  // The name of the scene you want to load.
    public Text interactText;  // Reference to the UI Text element.

    private bool inZone = false;

    void Start()
    {
        interactText.enabled = false; // Hide the "Press E" text initially.
    }

    void Update()
    {
        if (inZone)
        {
            interactText.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                LoadScene();
            }
        }
        else
        {
            interactText.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the player has a specific tag.
        {
            inZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inZone = false;
            interactText.enabled = false;
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
