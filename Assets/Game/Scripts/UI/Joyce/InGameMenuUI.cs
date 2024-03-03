using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuUI : MonoBehaviour
{
    [SerializeField] GameObject[] menuPanels;
    [SerializeField] Button[] menuButtons;
    [SerializeField] MapPanel mapPanel;

    void Start()
    {
        for (int i = 0; i < menuButtons.Length; i++)
        {
            int panelIndex = i;
            menuButtons[i].onClick.AddListener(() => SetPanelActive(panelIndex));
        }
    }

    void SetPanelActive(int index)
    {
        for (int i = 0; i < menuPanels.Length; i++)
        {
            menuPanels[i].SetActive(i == index);
        }
    }

    public void OnMapButton()
    {
        mapPanel.ClickMapButton();
    }
}
