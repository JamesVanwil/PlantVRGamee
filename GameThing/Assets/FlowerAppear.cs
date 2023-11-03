using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAppear : MonoBehaviour
{

    public GameObject cubeToDisappear; // Reference to the cube that will disappear
    public GameObject cubeToAppear;    // Reference to the cube that will appear

    private bool hasSwitched = false;  // Track whether the cubes have been switched

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSwitched)
        {
            if (other.gameObject == cubeToDisappear)
            {
                cubeToDisappear.SetActive(false); // Hide the cube to disappear
                cubeToAppear.SetActive(true);     // Show the cube to appear
                hasSwitched = true;              // Mark the switch as complete
            }
        }
    }
}


