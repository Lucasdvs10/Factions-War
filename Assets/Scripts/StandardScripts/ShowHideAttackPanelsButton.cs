using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideAttackPanelsButton : MonoBehaviour{
    [SerializeField] private List<GameObject> _gameObjectsList;
    private bool _activated;

    public void ShowHideAttackPanels() {
        Text t = transform.Find("Text").GetComponent<Text>();
        
        if (_gameObjectsList.Count <= 0) return; //Guardian Claw

        
        if (!_activated) {
            t.text = "Exibir painéis de ataque";
            _activated = true;
        }

        else {
            t.text = "Esconder painéis de ataque";
            _activated = false;
        }


        foreach (var gameObj in _gameObjectsList) {
            gameObj.SetActive(!_activated);
        }
    }
}







