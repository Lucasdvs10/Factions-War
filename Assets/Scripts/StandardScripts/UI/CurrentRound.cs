using UnityEngine;
using UnityEngine.UI;
public class CurrentRound : MonoBehaviour
{
    private int _currentRound;
    [SerializeField]private Text _textCurrentRound;

    //Refreshes the ui text to the corresponding text
    public void RefreshTheCurrentRound(int n)
    {
        _currentRound = n;
        _textCurrentRound.text = n.ToString();
    }

    void Update()
    {
        RefreshTheCurrentRound(_currentRound);
    }
}
