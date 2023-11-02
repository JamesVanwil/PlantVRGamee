using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAppear: MonoBehaviour
{
    public GameObject cubeToDisappear;
    public GameObject objectToAppear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == cubeToDisappear)
        {
            Debug.Log("Trigger entered by cubeToDisappear");
            objectToAppear.SetActive(true);   // Show the new object
            cubeToDisappear.SetActive(false); // Hide the cube
        }
        else
        {
            Debug.Log("Trigger entered by something else");
        }
    }

}
