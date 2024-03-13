using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : Entity
{
    #region STATES
    
    public ShieldEnemyIdleState IdleState { get; private set; }
    public ShieldEnemyMoveState moveState { get; private set; }    
    
    public ShieldEnemyPlayerDetectedState PlayerDetectedState { get; private set; }

    #endregion

    #region DATA

    [SerializeField] private D_IdleState _idleStateData;
    [SerializeField] private D_MoveState _moveStateData;
    [SerializeField] private D_PlayerDetected _playerDetectedData;
    #endregion


    public override void Start()
    {
        base.Start();
        moveState = new ShieldEnemyMoveState(this, _finiteStateMachine, "move", _moveStateData, this);
        IdleState = new ShieldEnemyIdleState(this, _finiteStateMachine, "idle", _idleStateData, this);
        PlayerDetectedState =
            new ShieldEnemyPlayerDetectedState(this, _finiteStateMachine, "playerDetected", _playerDetectedData, this);
        _finiteStateMachine.Initialize(moveState);
    }
}
