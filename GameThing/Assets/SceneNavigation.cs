using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    // The name of the scene you want to switch to.
    public string targetSceneName;

    void Update()
    {
        // Check if the 'E' key is pressed.
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Load the target scene.
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
