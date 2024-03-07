using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuUI : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject[] menuPanels;
    [SerializeField] Button[] menuButtons;
    [SerializeField] MapPanel mapPanel;
    [SerializeField] ItemPanel itemPanel;
    [SerializeField] CharacterPanel characterPanel;
    [SerializeField] GameObject discriptionHolder;

    void Start()
    {
        /*for (int i = 0; i < menuButtons.Length; i++)
        {
            int panelIndex = i;
            menuButtons[i].onClick.AddListener(() => SetPanelActive(panelIndex));
        }*/
    }

    /*void SetPanelActive(int index)
    {
        for (int i = 0; i < menuPanels.Length; i++)
        {
            menuPanels[i].SetActive(i == index);
        }
    }*/

    public void CloseInGameMenu()
    {
        if (mapPanel.gameObject.activeSelf)
        {
            mapPanel.FoldMap();
            Invoke("DeactiveMenu", 0.6f);
        }
        else
        {
            mapPanel.MoveToOriginalPosition();
            characterPanel.MoveToOriginalPosition();
            itemPanel.MoveToOriginalPosition();
        }

    }
    
    void DeactiveMenu()
    {
        menuPanel.SetActive(false);
    }

    public void OpenInGameMenu()
    {
        menuPanel.SetActive(true);
    }

    public void OnMapButton()
    {
        discriptionHolder.SetActive(false);
        mapPanel.UnfoldMap();
        mapPanel.MoveToOriginalPosition();
        itemPanel.MoveToOriginalPosition();
        characterPanel.MoveToOriginalPosition();
    }

    public void OnCharacterButton()
    {
        mapPanel.FoldMap();
        mapPanel.MoveToTargetPosition();
        itemPanel.MoveToMapPosition();
        characterPanel.MoveToOriginalPosition();
    }

    public void OnItemButton()
    {
        mapPanel.FoldMap();
        mapPanel.MoveToTargetPosition();
        itemPanel.MoveToTargetDisplayPosition();
        characterPanel.MoveToOriginalPosition();
    }

    public void OnOptionButton()
    {
        mapPanel.FoldMap();
        mapPanel.MoveToTargetPosition();
        itemPanel.MoveToMapPosition();
        characterPanel.MoveToTargetPosition();
    }

}
