using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class SpawnAreaScript : MonoBehaviour {
    [SerializeField] private GameObject character;
    [SerializeField] private int offSet = 12;
    [SerializeField] GameObject currentMoney;
    
    public static event Action CharacterCreationEvent;
    public event Action<GameObject> CharacterChangedEvent;

    public void SetCharacter(GameObject newCharacter){
        character = newCharacter;   
        CharacterChangedEvent?.Invoke(newCharacter);
    }
    
    // Spawning Method
    public void OnMouseDown()
    {
        //Checks if there is money to place a character
        if(currentMoney.GetComponent<CurrentMoney>().UpdateMoney(-20)) //TODO: Update this area when character cost become avaiable
        {
            Instantiate(character, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * offSet, Quaternion.identity);
        
            CharacterCreationEvent?.Invoke();
        }

    }
    
    private void OnDrawGizmos() {
        var collider = GetComponent<BoxCollider2D>();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + new Vector3(collider.offset.x, collider.offset.y, 0), collider.bounds.extents * 2);
    }
}