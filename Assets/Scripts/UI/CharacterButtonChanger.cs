using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonChanger : MonoBehaviour
{
    public SpawnAreaScript spawnAreacript;
    public GameObject character;

    //Sets onClick event
    private void Start() {
        GetComponent<Button>().onClick.AddListener(ChangeGameObject);
    }

    //Selects which character will be spawned
    private void ChangeGameObject(){ 
        spawnAreacript.SetCharacter(character);
    }

}
