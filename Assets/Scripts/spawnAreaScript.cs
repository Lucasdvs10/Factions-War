using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class SpawnAreaScript : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private int offSet = 12;


    public void SetCharacter(GameObject newCharacter){
        character = newCharacter;   
        CharacterChangedEvent?.Invoke(newCharacter);
    
    }
    public static event Action CharacterCreationEvent;
    public event Action<GameObject> CharacterChangedEvent;

    // Spawning Method
    public void OnMouseDown(){
            Instantiate(character, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * offSet, Quaternion.identity);
            
            CharacterCreationEvent?.Invoke();
            
            // Debug just to test if the code is working :)
           // Debug.Log("ta spawnando");

    }
    
    private void OnDrawGizmos() {
        var collider = GetComponent<BoxCollider2D>();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + new Vector3(collider.offset.x, collider.offset.y, 0), collider.bounds.extents * 2);
    }
}
