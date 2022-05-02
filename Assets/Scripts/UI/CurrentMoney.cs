using UnityEngine;
using UnityEngine.UI;

public class CurrentMoney : MonoBehaviour
{
    [SerializeField] private int _currentMoney;
    [SerializeField] private Text _textCurrentMoney;


    void Update()
    {
        _textCurrentMoney.text = "Money: " + _currentMoney.ToString();
    }

    //Updates the ammount of money the player currently have
    public void UpdateMoney(int value) {
        //Maybe control money limit with Mathf.Clamp
        _currentMoney += value;
        _currentMoney = Mathf.Clamp(_currentMoney, 0, 10000);
    }

    public int GetCurrentMoney => _currentMoney;
}