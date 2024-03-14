using System;
using System.Collections;
using System.Collections.Generic;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCheck : MonoBehaviour
{
    public bool isAlive = true;
    public GameObject AliveGO;
    public Scene originalScene;
    public Transform originalTransform;
    public Transform originalALIVEGOTransform;
    
    private void Awake()
    {
        originalScene = gameObject.scene;
        originalTransform = gameObject.transform;
        originalALIVEGOTransform = AliveGO.transform;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        GameManager.Instance.RegisterEnemy(this);
        Debug.Log(originalScene.name);
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene current)
    {
        if (!originalScene.isLoaded)
        {
            AliveGO.SetActive(false);
        }
    }
    
    public void DESPAWN()
    {
        isAlive = false;
        AliveGO.SetActive(false);
    }
    
    public void RESPAWN()
    {
        isAlive = true;
        this.gameObject.transform.position = originalTransform.position;
        AliveGO.transform.position = originalTransform.position;
        AliveGO.SetActive(true);
    }
    
    
    
}
