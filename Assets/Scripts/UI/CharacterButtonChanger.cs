using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonChanger : MonoBehaviour
{
    public SpawnAreaScript spawnAreacript;
    public GameObject character;

    private void Start() {
        GetComponent<Button>().onClick.AddListener(ChangeGameObject);
    }
    private void ChangeGameObject(){ 
        spawnAreacript.SetCharacter(character);
    }

}
