using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInPot : MonoBehaviour
{
    public GameObject Flower;  // Assign the item to disappear in the Inspector
    public GameObject FlowerInPot;     // Assign the item to spawn in the Inspector
    public GameObject FlowerName;


    private void Start()
    {
        // Make the item to spawn inactive at the beginning
        FlowerInPot.SetActive(false);
        FlowerName.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Flower)
        {
            // Make the item to disappear inactive
            Flower.SetActive(false);

            FlowerInPot.SetActive(true);
            FlowerName.SetActive(true);
        }
    }
}
