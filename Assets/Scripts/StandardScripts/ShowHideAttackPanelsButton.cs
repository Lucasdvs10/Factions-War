using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideAttackPanelsButton : MonoBehaviour
{

    [SerializeField] private GameObject northPanel;
    [SerializeField] private GameObject southPanel;
    [SerializeField] private GameObject eastPanel;
    [SerializeField] private GameObject westPanel;

    public void ShowHideAttackPanels()
    {
        if (northPanel != null && southPanel != null && eastPanel != null && westPanel != null)
        {
            if (northPanel.activeSelf && southPanel.activeSelf && eastPanel.activeSelf && westPanel.activeSelf)
            {
                northPanel.SetActive(false);
                southPanel.SetActive(false);
                eastPanel.SetActive(false);
                westPanel.SetActive(false);
                Text t = transform.Find("Text").GetComponent<Text>();
                t.text = "Exibir painéis de ataque";
            }
            else
            {
                northPanel.SetActive(true);
                southPanel.SetActive(true);
                eastPanel.SetActive(true);
                westPanel.SetActive(true);
                Text t = transform.Find("Text").GetComponent<Text>();
                t.text = "Esconder painéis de ataque";
            }
        }
    }
}
