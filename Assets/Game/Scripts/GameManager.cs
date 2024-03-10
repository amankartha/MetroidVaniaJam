using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Scene.Interactables;
using Game.Scripts.System;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Events;
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
    
    #endregion

    #region EVENTS

    public UnityEvent OnPlayerHealthChanged;
    public UnityEvent OnPlayerDamaged;
    public UnityEvent<Collectable> OnPlayerCollectable;

    #endregion
    
    #region UNITYMETHODS
    void Start()
    {
    }
    
    void Update()
    {
        
    }
    #endregion
  
}
