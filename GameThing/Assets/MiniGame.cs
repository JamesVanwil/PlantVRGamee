using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame : MonoBehaviour
{
    public Transform BluezoneTransform;
    public Transform PinkzoneTransform;

    public GameObject CorrectCubeBlue;
    public GameObject CorrectBlueCubeToAppear;

    public GameObject CorrectCubePink;
    public GameObject CorrectPinkCubeToAppear;

    private bool blueCubeCorrectlyPlaced = false;
    private bool pinkCubeCorrectlyPlaced = false;

    public Transform teleportTarget;
    public GameObject Player;

    public GameObject GoBackLever;


    private void Start()
    {
        
    }
    void Update()
    {
        CorrectBlueCube();
        CorrectPinkCube();

        // Check if both cubes are correctly placed and appearance objects are active
        if (blueCubeCorrectlyPlaced && pinkCubeCorrectlyPlaced &&
            CorrectBlueCubeToAppear.activeSelf && CorrectPinkCubeToAppear.activeSelf)
        {
            // Teleport the player character
            GoBackLever.SetActive(true);
        }
    }

    private void CorrectBlueCube()
    {
        float distance = Vector3.Distance(CorrectCubeBlue.transform.position, BluezoneTransform.position);
        float thresholdDistance = 1.0f;

        if (distance < thresholdDistance)
        {
            Renderer seedRenderer = CorrectCubeBlue.GetComponent<Renderer>();
            Collider seedCollider = CorrectCubeBlue.GetComponent<Collider>();

            seedRenderer.enabled = false;
            seedCollider.enabled = false;

            CorrectBlueCubeToAppear.SetActive(true);

            // Mark the blue cube as correctly placed
            blueCubeCorrectlyPlaced = true;
        }
    }

    private void CorrectPinkCube()
    {
        float distance = Vector3.Distance(CorrectCubePink.transform.position, PinkzoneTransform.position);
        float thresholdDistance = 1.0f;

        if (distance < thresholdDistance)
        {
            Renderer seedRenderer = CorrectCubePink.GetComponent<Renderer>();
            Collider seedCollider = CorrectCubePink.GetComponent<Collider>();

            seedRenderer.enabled = false;
            seedCollider.enabled = false;

            CorrectPinkCubeToAppear.SetActive(true);

            // Mark the pink cube as correctly placed
            pinkCubeCorrectlyPlaced = true;
        }
    }

    public void TeleportPlayerToDestination()
    {
        Player.transform.position = teleportTarget.transform.position;
    }
}
