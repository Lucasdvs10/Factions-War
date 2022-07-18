using UnityEngine;
using UnityEngine.UI;


public class CurrentRound : MonoBehaviour{
    private int _currentRound;
    private Text _text;

    
    void Awake() {
        _text = GetComponent<Text>();

    }


    private void Start() {
        _currentRound = 0;
        _text.text = _currentRound.ToString();
    }
    
    public void AddOneRoundAndUpdateUI() {
        _currentRound++;
        _text.text = _currentRound.ToString();
    }
    
}
