using System;
using System.Collections;
using System.Collections.Generic;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
   
    [Header("Main Menu Objects")]
    [SerializeField] private GameObject _loadingBarGO;
    [SerializeField] private Image _loadingBarImage;
    [SerializeField] private GameObject[] _objectsToHide;
    [SerializeField] private GameObject _quitPanel;
    [SerializeField] private Animator _quitPanelAnimator;
    [SerializeField] private UIPaperFold uiPaperFold;
    [SerializeField] private TMP_Text _titleText;

    [Header("Scenes to load")] 
    [SerializeField] private SceneReference _persistentGameplayScene;
    [SerializeField] private SceneReference _levelScene;

    private List<AsyncOperation> _scenesToLoad = new List<AsyncOperation>();
    #region UNITYMETHODS

    private void Awake()
    {
        _loadingBarGO.SetActive(false);
    }

    #endregion


    #region METHODS

    private void HideMenu()
    {
        for (int i = 0; i < _objectsToHide.Length; i++)
        {
            _objectsToHide[i].SetActive(false);
        }
    }
    
    
    public void StartGame()
    {
        HideMenu();
        _loadingBarGO.SetActive(true);
        
        SceneManager.LoadSceneAsync(_persistentGameplayScene.BuildIndex);
        SceneManager.LoadSceneAsync(_levelScene.BuildIndex,LoadSceneMode.Additive);

        StartCoroutine(ProgressLoadingBar());
    }

    public void OnCreditButton()
    {
        _titleText.text = "CREDIT";
        uiPaperFold.StartFolding();
    }

    public void OnOptionButton()
    {
        _titleText.text = "OPTION";
        uiPaperFold.StartFolding();
    }

    public void OnFlipBackButton()
    {
        uiPaperFold.FoldingBack();
    }

    public void OnQuitButton()
    {
        if (_quitPanel.activeSelf == false)
        {
            _quitPanel.SetActive(true);
            _quitPanelAnimator.SetBool("Quit", true);
        }       
    }

    public void OnConfirmQuitButton()
    {
        Application.Quit();
    }

    public void OnCancelQuitButton()
    {
        _quitPanelAnimator.SetBool("Quit", false);
        Invoke("HideQuitPanel", _quitPanelAnimator.GetCurrentAnimatorClipInfo(0).Length + 0.1f);
    }

    void HideQuitPanel()
    {
        _quitPanel.SetActive(false);
    }


    private IEnumerator ProgressLoadingBar()
    {
        float loadProgress = 0f;
        for (int i = 0; i <_scenesToLoad.Count; i++)
        {
            while (!_scenesToLoad[i].isDone)
            {
                loadProgress += _scenesToLoad[i].progress;
                _loadingBarImage.fillAmount = loadProgress / _scenesToLoad.Count;
                yield return null;
            }
        }
    }




    #endregion
}
