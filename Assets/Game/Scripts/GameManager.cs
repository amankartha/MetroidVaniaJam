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
    public UnityEvent<int> OnPotionChange;
    public UnityEvent<Collectable> OnPlayerCollectable;
    public UnityEvent OnPlayerDeath;
    public UnityEvent OnUpdatedRespawnPoint;
    public UnityEvent OnThrowCooldownChanged;
    public UnityEvent OnNewRoomDiscovered;
    
    #endregion

    #region ENEMIES

    public Dictionary<int,EnemyCheck> EnemyDictionary = new Dictionary<int, EnemyCheck>();


    #endregion
    
    
    #region UNITYMETHODS
    void Start()
    {
        OnPlayerDeath.AddListener(RespawnPlayer);
    }
    
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        OnPlayerDeath.RemoveListener(RespawnPlayer);
    }

    #endregion

    #region Methods

    public void RespawnPlayer()
    {
        Debug.Log("AAA");
        goMainPlayer.transform.position = CurrentRespawnPoint.RespawnLocation.position;
        PlayerScript.PlayerHealth.SetHealth(PlayerScript.PlayerHealth.MaxHealth);
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

    #endregion
}
