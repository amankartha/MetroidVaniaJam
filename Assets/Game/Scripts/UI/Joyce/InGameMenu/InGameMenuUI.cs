using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using DG.Tweening;


public class InGameMenuUI : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] GameObject[] menuPanels;
    [SerializeField] Button[] menuButtons;
    [SerializeField] MapPanel mapPanel;
    [SerializeField] ItemPanel itemPanel;
    [SerializeField] CharacterPanel characterPanel;
    [SerializeField] GameObject discriptionHolder;

    bool isMenuOpened = false;

    public float tabMoveDistance = 5f;

    int currentTabIndex = 0;
    int previousTabIndex = 0;
    List<RectTransform> menuButtonRects = new List<RectTransform>();

    public Map map;

    void Start()
    {
        /*for (int i = 0; i < menuButtons.Length; i++)
        {
            int panelIndex = i;
            menuButtons[i].onClick.AddListener(() => SetPanelActive(panelIndex));
        }*/

        canvasGroup.alpha = 0;
        foreach (Button button in menuButtons)
        {
            menuButtonRects.Add(button.GetComponent<RectTransform>());
        }
    }

    /*void SetPanelActive(int index)
    {
        for (int i = 0; i < menuPanels.Length; i++)
        {
            menuPanels[i].SetActive(i == index);
        }
    }*/

    private void Update()
    {
        if (isMenuOpened)
        {
            CheckTabSwitchingInput();
        }

        if (GameManager.Instance.PlayerInputHandler.MapInput)
        {
            GameManager.Instance.PlayerInputHandler.UseMapInput();

            if (!isMenuOpened)
            {
                OpenInGameMenu();
            }
            else
            {
                CloseInGameMenu();
            }
        }
  
    }

    void CheckTabSwitchingInput()
    {
        if (GameManager.Instance.PlayerInputHandler.MenuTabUpInput)
        {
            GameManager.Instance.PlayerInputHandler.UseMenuTabUpInput();

            int index = currentTabIndex - 1;
            if (index < 0)
            {
                index = menuButtons.Length - 1;
            }
            menuButtons[index].onClick.Invoke();
            currentTabIndex = index;
        }
        if (GameManager.Instance.PlayerInputHandler.MenuTabDownInput)
        {
            GameManager.Instance.PlayerInputHandler.UseMenuTabDownInput();

            int index = currentTabIndex + 1;
            if (index >= menuButtons.Length)
            {
                index = 0;
            }
            menuButtons[index].onClick.Invoke();
            currentTabIndex = index;
        }
    }

    public void CloseInGameMenu()
    {
        RectTransform rect = menuButtonRects[currentTabIndex];
        rect.DOMoveX(rect.position.x + tabMoveDistance, 0.3f).SetUpdate(true);
        ResetIndexes();

        if (!mapPanel.isFolded)
        {
            mapPanel.FoldMap();           
            Invoke("DeactiveMenu", 0.1f);
        }
        else
        {
            discriptionHolder.SetActive(false);
            mapPanel.MoveToOriginalPosition();
            characterPanel.MoveToOriginalPosition();
            itemPanel.MoveToOriginalPosition();
            Invoke("DeactiveMenu", 0.5f);
        }
        isMenuOpened = false;
        Time.timeScale = 1;
    }

    void DeactiveMenu()
    {
        canvasGroup.DOFade(0f, 0.4f).SetUpdate(true)
            .OnComplete(() => menuPanel.SetActive(false));
    }

    public void OpenInGameMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0;
        canvasGroup.DOFade(1f, 0.4f).SetUpdate(true);
        OnMapButton();
        isMenuOpened = true;
    }

    public void OpenInGameMenuWithItemTab()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0;
        canvasGroup.DOFade(1f, 0.4f).SetUpdate(true);
        currentTabIndex = 2;
        previousTabIndex = 2;
        OnItemButton();
        isMenuOpened = true;
    }

    public void OnMapButton()
    {
        previousTabIndex = currentTabIndex;
        currentTabIndex = 0;
        discriptionHolder.SetActive(false);
        mapPanel.UnfoldMap();
        mapPanel.MoveToOriginalPosition();
        itemPanel.MoveToOriginalPosition();
        characterPanel.MoveToOriginalPosition();
        MoveSelectedTab();
        if (mapPanel.isZoomedIn)
        {
            map.ShowRegionalMap();
        }
    }

    public void OnCharacterButton()
    {
        previousTabIndex = currentTabIndex;
        currentTabIndex = 1;
        characterPanel.UpdateInventoryText();
        mapPanel.FoldMap();
        mapPanel.MoveToTargetPosition();
        itemPanel.MoveToMapPosition();
        characterPanel.MoveToOriginalPosition();
        MoveSelectedTab();
        CheckMapZoom();
    }

    public void OnItemButton()
    {
        previousTabIndex = currentTabIndex;
        currentTabIndex = 2;
        mapPanel.FoldMap();
        mapPanel.MoveToTargetPosition();
        itemPanel.MoveToTargetDisplayPosition();
        characterPanel.MoveToOriginalPosition();
        MoveSelectedTab();
        CheckMapZoom();
    }

    public void OnOptionButton()
    {
        previousTabIndex = currentTabIndex;
        currentTabIndex = 3;
        mapPanel.FoldMap();
        mapPanel.MoveToTargetPosition();
        itemPanel.MoveToMapPosition();
        characterPanel.MoveToTargetPosition();
        MoveSelectedTab();
        CheckMapZoom();
    }

    void MoveSelectedTab()
    {
        RectTransform rect = menuButtonRects[currentTabIndex];
        rect.DOMoveX(rect.position.x - tabMoveDistance, 0.3f).SetUpdate(true);

        if (previousTabIndex != currentTabIndex)
        {
            rect = menuButtonRects[previousTabIndex];
            rect.DOMoveX(rect.position.x + tabMoveDistance, 0.3f).SetUpdate(true);
        }

    }

    void ResetIndexes()
    {
        currentTabIndex = 0;
        previousTabIndex = 0;
    }

    void CheckMapZoom()
    {
        if (mapPanel.isZoomedIn)
        {
            map.HideRegionalMap();
        }
    }

}
