using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject canvasPrefab;
    bool canvasSpawned;

    void Start()
    {
        canvasSpawned = false;
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        if (GameObject.FindGameObjectWithTag("Canvas") == null && !canvasSpawned)
        {
            canvasSpawned = true;
            Instantiate(canvasPrefab, transform.position, Quaternion.identity);
        }


    }
}
