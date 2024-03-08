using System.Collections;
using System.Collections.Generic;
using Game.Scripts.System;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MMPersistentSingleton<GameManager>
{
    #region GLOBALVARIABLES
    
    
    //main player stuff
    public GameObject goMainPlayer;
    public Transform tMainPlayer;
    public Player PlayerScript;
    public PlayerHealth PlayerHealthScript;
    public PlayerInputHandler PlayerInputHandler;

    public Map mapScript;
    public GameObject goHUD;
    
    #endregion

    #region EVENTS

    public UnityEvent PlayerHealthChanged;

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
