using System;
using System.Collections;
using System.Collections.Generic;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
    [SerializeField] private SceneReference[] _scenesToLoad;
    [SerializeField] private SceneReference[] _scenesToUnload;


    #region UNITYMETHODS

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == GameManager.Instance.goMainPlayer)
        {
            LoadScenes();
            UnloadScene();
        }
    }

    #endregion

    #region Methods


    private void LoadScenes()
    {
       
        for (int i = 0; i < _scenesToLoad.Length; i++)
        {
            bool isSceneLoaded = false;
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                if (loadedScene.name == _scenesToLoad[i].Name)
                {
                    isSceneLoaded = true;
                    break;
                }
            }

            if (!isSceneLoaded)
            {
                SceneManager.LoadSceneAsync(_scenesToLoad[i].BuildIndex, LoadSceneMode.Additive);
            }
        }
    }

    private void UnloadScene()
    {
        for (int i = 0; i < _scenesToUnload.Length; i++)
        {
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                if (loadedScene.name == _scenesToUnload[i].Name)
                {
                    SceneManager.UnloadSceneAsync(_scenesToUnload[i].BuildIndex);
                }
                    
            }
        }
    }
    

    #endregion
}
