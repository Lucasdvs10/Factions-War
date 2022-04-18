using System;
using UnityEngine;

public class spawnAreaScript : MonoBehaviour
{
    [SerializeField] private GameObject tropa;
    [SerializeField] private int offSet = 12;

    public static event Action OnTropaInstatiation;
    
    // Spawning Method
    public void OnMouseDown(){
            Instantiate(tropa, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * offSet, Quaternion.identity);
            
            OnTropaInstatiation?.Invoke();
            
            // Debug just to test if the code is working :)
            Debug.Log("ta spawnando");

    }
}
