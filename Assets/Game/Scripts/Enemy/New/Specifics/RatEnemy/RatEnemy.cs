using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemy : Entity
{
    #region STATES
    
    public RatEnemyIdleState IdleState { get; private set; }
    public RatEnemyMoveState moveState { get; private set; }    

    #endregion

    #region DATA

    [SerializeField] private D_IdleState _idleStateData;
    [SerializeField] private D_MoveState _moveStateData;

    #endregion


    public override void Start()
    {
        base.Start();
        moveState = new RatEnemyMoveState(this, _finiteStateMachine, "move", _moveStateData,this);
        IdleState = new RatEnemyIdleState(this, _finiteStateMachine, "idle", _idleStateData,this);
        
        _finiteStateMachine.Initialize(moveState);
    }
    
}
