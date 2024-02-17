using System;
using System.Collections;
using System.Collections.Generic;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
   
    [Header("Main Menu Objects")]
    [SerializeField] private GameObject _loadingBarGO;
    [SerializeField] private Image _loadingBarImage;
    [SerializeField] private GameObject[] _objectsToHide;

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
