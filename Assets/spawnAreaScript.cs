using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAreaScript : MonoBehaviour
{
    public GameObject tropa;

    public int offSet = 12;


    // Spawning Method
    public void OnMouseDown() 
    {
            Instantiate(tropa, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * offSet, Quaternion.identity);
            
            // Debug just to test if the code is working :)
            Debug.Log("ta spawnando");

    }
}
