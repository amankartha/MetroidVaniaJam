using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Scene.Interactables;
using Game.Scripts.System;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MMPersistentSingleton<GameManager>
{
    #region GLOBALVARIABLES


    #region MAINPLAYERRELATED

  

    
    public GameObject goMainPlayer;
    public Transform tMainPlayer;
    public Player PlayerScript;
    public PlayerHealth PlayerHealthScript;
    public PlayerInputHandler PlayerInputHandler;
    #endregion

    public InteractablesData _interactablesData;
    public Map mapScript;
    public GameObject goHUD;
    public GameObject goInGameMenu;

    public RespawnPoint CurrentRespawnPoint;
    #endregion

    #region EVENTS

    public UnityEvent OnPlayerHealthChanged;
    public UnityEvent OnPlayerDamaged;
    public UnityEvent OnPotionChange;
    public UnityEvent<Collectable> OnPlayerCollectable;
    public UnityEvent OnPlayerDeath;
    public UnityEvent OnUpdatedRespawnPoint;
    public UnityEvent OnThrowCooldownChanged;
    public UnityEvent OnNewRoomDiscovered;
    public UnityEvent OnThrowIconChange;
    
    #endregion

    #region ENEMIES

    public Dictionary<int,EnemyCheck> EnemyDictionary = new Dictionary<int, EnemyCheck>();


    #endregion
    
    
    #region UNITYMETHODS
    void Start()
    {
        OnPlayerDeath.AddListener(RespawnPlayer);
        SceneManager.sceneLoaded += OnMainMenuLoad;
    }
    
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnMainMenuLoad;
        OnPlayerDeath.RemoveListener(RespawnPlayer);
    }

    #endregion
    
    #region Methods

    public void RespawnPlayer()
    {
        
        goMainPlayer.transform.position = CurrentRespawnPoint.RespawnLocation.position;
        PlayerScript.RefillPotionsAndHealth();
        PlayerScript.SetVelocityZero();
        RespawnAllEnemies();
    }

    public void RegisterEnemy(EnemyCheck enemyCheck)
    {
        EnemyDictionary.Add(enemyCheck.gameObject.GetInstanceID(), enemyCheck);
    }

    public void RespawnAllEnemies()
    {
        foreach (var enemy in EnemyDictionary)
        {
            if (SceneManager.GetSceneByName(enemy.Value.originalScene.name).isLoaded)
            {
                enemy.Value.RESPAWN();
            }
        }
    }

    public void OnMainMenuLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            Destroy(this.gameObject);
        }
    }
    

    #endregion
}
