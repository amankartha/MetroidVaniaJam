using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : Entity
{
    #region STATES
    
    public ShieldEnemyIdleState IdleState { get; private set; }
    public ShieldEnemyMoveState moveState { get; private set; }    

    #endregion

    #region DATA

    [SerializeField] private D_IdleState _idleStateData;
    [SerializeField] private D_MoveState _moveStateData;

    #endregion


    public override void Start()
    {
        base.Start();
        moveState = new ShieldEnemyMoveState(this, _finiteStateMachine, "move", _moveStateData, this);
        IdleState = new ShieldEnemyIdleState(this, _finiteStateMachine, "idle", _idleStateData, this);
        
        _finiteStateMachine.Initialize(moveState);
    }
}
