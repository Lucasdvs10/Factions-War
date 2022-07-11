using System;
using UnityEngine;

namespace StandardScripts{
    [RequireComponent(typeof(Collider2D))]

    public class SpawnAreaScript : MonoBehaviour, IEventEmitter{
        [SerializeField] private GameObject character;
        [SerializeField] private int offSet = 12;
        [SerializeField] CurrentMoney currentMoney;

        int characterCost = 0;
    
        public event Action CharacterCreationEvent;
        public event Action<GameObject> CharacterSpawnedEvent;

        private void Start() {
            var buttonChangersList = FindObjectsOfType<CharacterButtonChanger>();
            if(buttonChangersList != null) {
                foreach (var button in buttonChangersList) {
                    button.SpawnAreaScriptsList.Add(this);
                }
            }
        }

        public void SetCharacter(GameObject newCharacter, int value) {
            character = newCharacter;  
            if (newCharacter == null) return;
            CharacterSpawnedEvent?.Invoke(newCharacter);
            characterCost = value;
        }
    
        // Spawning Method
        public void OnMouseDown() {
            //Checks if there is money to place a character

            if (character == null) return;
        
            if(currentMoney.GetCurrentMoney >= characterCost)
            {
                Instantiate(character, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * offSet, Quaternion.identity);
        
                currentMoney.UpdateMoney(-characterCost);
            
                CharacterCreationEvent?.Invoke();
            }
        }
    
    }
}