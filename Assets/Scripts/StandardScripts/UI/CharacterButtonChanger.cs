using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonChanger : MonoBehaviour
{
    public List<SpawnAreaScript> SpawnAreaScriptsList;
    public GameObject _character;

    //Sets onClick event
    private void Start() {
        GetComponent<Button>().onClick.AddListener(ChangeGameObject);
    }

    //Selects which character will be spawned
    private void ChangeGameObject(){

        foreach (var spawnAreaScript in SpawnAreaScriptsList) {
            spawnAreaScript.SetCharacter(_character, int.Parse(transform.GetChild(0).GetComponent<Text>().text));
        }
    }

}
