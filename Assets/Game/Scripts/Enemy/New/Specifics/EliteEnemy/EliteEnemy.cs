using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemy : Entity
{
    #region States

    public EliteEnemyIdleState IdleState { get; private set; }
    public EliteEnemyMoveState MoveState { get; private set; }

    #endregion

    #region Data

    [SerializeField] private D_IdleState _idleData;
    [SerializeField] private D_MoveState _moveData;


    #endregion

    #region UNITYCALLBACKS

    public override void Start()
    {
        base.Start();

        IdleState = new EliteEnemyIdleState(this, _finiteStateMachine, "idle", _idleData, this);
        MoveState = new EliteEnemyMoveState(this, _finiteStateMachine, "move", _moveData, this);
        
        _finiteStateMachine.Initialize(IdleState);
    }

    #endregion
}
