using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class GameManager : MMPersistentSingleton<GameManager>
{
    #region GLOBALVARIABLES
    
    
    //main player stuff
    public GameObject goMainPlayer;
    public Transform tMainPlayer;
    public Player PlayerScript;

    public Map mapScript;
    
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
