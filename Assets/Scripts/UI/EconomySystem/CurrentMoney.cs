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
    public bool UpdateMoney(int value)
    {
        //Maybe control money limit with Mathf.Clamp
        if(_currentMoney + value >= 0)
        {
            _currentMoney += value;
            return true;
        }
        return false;
    }
}