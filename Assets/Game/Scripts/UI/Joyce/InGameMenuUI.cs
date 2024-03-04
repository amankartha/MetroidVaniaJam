using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class InGameMenuUI : MonoBehaviour
{
    [SerializeField] GameObject[] menuPanels;
    [SerializeField] Button[] menuButtons;
    [SerializeField] MapPanel mapPanel;
    [SerializeField] CharacterPanel characterPanel;

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
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
        {
            if (mapPanel.gameObject.activeSelf)
            {
                mapPanel.ToggleMapPanel();
            }
            else if (characterPanel.gameObject.activeSelf)
            {
                characterPanel.MoveToOriginalPosition();
            }
        });
        sequence.AppendInterval(0.6f);
        sequence.AppendCallback(() =>
        {
            for (int i = 0; i < menuPanels.Length; i++)
            {
                menuPanels[i].SetActive(i == index);
            }
        });
       
    }

    void DelayPanelActive()
    {
        
    }
    public void OnMapButton()
    {
        /*menuPanels[0].SetActive(true);
        mapPanel.ClickMapButton();*/
    }

    public void OnCharacterButton()
    {
    } 

    public void OnItemButton()
    {
    }

    void CloseMapPanel()
    {
        mapPanel.ToggleMapPanel();
    }
}
