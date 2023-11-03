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

    public Transform teleportLocation;
    public GameObject playerCharacter;

    void Update()
    {
        CorrectBlueCube();
        CorrectPinkCube();

        // Check if both cubes are correctly placed and appearance objects are active
        if (blueCubeCorrectlyPlaced && pinkCubeCorrectlyPlaced &&
            CorrectBlueCubeToAppear.activeSelf && CorrectPinkCubeToAppear.activeSelf)
        {
            // Teleport the player character
            TeleportPlayerToDestination();
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

    private void TeleportPlayerToDestination()
    {
        if (teleportLocation != null && playerCharacter != null)
        {
            // Set the player's position to the teleport destination's position
            playerCharacter.transform.position = teleportLocation.position;

            // Reset the player's velocity if it has a Rigidbody
            Rigidbody playerRigidbody = playerCharacter.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;
            }
        }
    }
}
