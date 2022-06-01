using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class SpawnAreaScript : MonoBehaviour {
    [SerializeField] private GameObject character;
    [SerializeField] private int offSet = 12;
    [SerializeField] CurrentMoney currentMoney;

    int characterCost = 0;
    
    public static event Action CharacterCreationEvent;
    public event Action<GameObject> CharacterChangedEvent;

    private void Start() {
       var buttonChangersList = FindObjectsOfType<CharacterButtonChanger>();
       if(buttonChangersList != null) {
           foreach (var button in buttonChangersList) {
               button.SpawnAreaScriptsList.Add(this);
           }
       }
    }

    public void SetCharacter(GameObject newCharacter, int value){
        character = newCharacter;   
        CharacterChangedEvent?.Invoke(newCharacter);
        characterCost = value;
    }
    
    // Spawning Method
    public void OnMouseDown() {
        //Checks if there is money to place a character
        
        if(currentMoney.GetCurrentMoney >= characterCost)
        {
            Instantiate(character, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * offSet, Quaternion.identity);
        
            currentMoney.UpdateMoney(-characterCost);
            
            CharacterCreationEvent?.Invoke();
        }
    }
    
}