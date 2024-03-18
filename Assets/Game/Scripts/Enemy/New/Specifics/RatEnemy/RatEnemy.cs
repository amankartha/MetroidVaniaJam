using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemy : Entity
{
    #region STATES
    
    public RatEnemyIdleState IdleState { get; private set; }
    public RatEnemyMoveState moveState { get; private set; }   
    
    public RatEnemyStunState StunState { get; private set; }

    #endregion

    #region DATA

    [SerializeField] private D_IdleState _idleStateData;
    [SerializeField] private D_MoveState _moveStateData;
    [SerializeField] private D_StunState _stunStateData;
   
    
    #endregion


    public override void Start()
    {
        base.Start();
        moveState = new RatEnemyMoveState(this, _finiteStateMachine, "move", _moveStateData,this);
        IdleState = new RatEnemyIdleState(this, _finiteStateMachine, "idle", _idleStateData,this);
        StunState = new RatEnemyStunState(this, _finiteStateMachine, "stun", _stunStateData, this);
        _finiteStateMachine.Initialize(moveState);
        
    }

    public override void Respawn()
    {
        base.Respawn();
        _finiteStateMachine?.Initialize(moveState);
    }

    public override void Damaged()
    {
        base.Damaged();
        _finiteStateMachine.ChangeState(StunState);
    }

  
}
