using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemCollector : MonoBehaviour
{
    public GameObject pineapplePrefab; // Reference to the Pineapple prefab
    public GameObject[] spawnLocations; // An array of spawn locations

    private bool hasRespawned = false;

    private void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("Spawn");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pineapple"))
        {
            Debug.Log("pinaple");
            RespawnPineapple();
        }
    }



    private int CountPineapples()
    {
        GameObject[] pineapples = GameObject.FindGameObjectsWithTag("Pineapple");
        Debug.Log(pineapples.Length);
        return pineapples.Length;
    }

    private void RespawnPineapple()
    {
        Debug.Log("RespawnEntered!");
        if (pineapplePrefab != null && spawnLocations.Length > 0)
        {
            
            int randomIndex = Random.Range(0, spawnLocations.Length);
            Transform spawnLocation = spawnLocations[randomIndex].transform;
            GameObject pineaplle = GameObject.FindGameObjectWithTag("Pineapple");
            pineaplle.transform.position = spawnLocation.position;

        }
        else
        {
            Debug.LogWarning("Pineapple prefab or spawn locations not set.");
        }
    }
}