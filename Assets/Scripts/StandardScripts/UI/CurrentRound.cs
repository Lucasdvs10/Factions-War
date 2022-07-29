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
        SetText();
    }
    
    public void AddOneRoundAndUpdateUI() {
        _currentRound++;
        SetText();
    }
    
    private void SetText() {
        _text.text = $"Round: {_currentRound.ToString()}";
    }

    
}
