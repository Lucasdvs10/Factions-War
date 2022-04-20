using UnityEngine;
using UnityEngine.UI;
public class CurrentMoney : MonoBehaviour
{
    private int _currentMoney;
    [SerializeField]private Text _textCurrentMoney;

    public void RefreshTheCurrentMoney(int n)
    {
        _textCurrentMoney.text = n.ToString();
    }
    void Update()
    {
        RefreshTheCurrentMoney(_currentMoney);
    }
}