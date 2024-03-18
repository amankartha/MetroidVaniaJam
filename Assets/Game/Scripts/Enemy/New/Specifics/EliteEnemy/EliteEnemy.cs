using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemy : Entity
{
    #region States

    public EliteEnemyIdleState IdleState { get; private set; }
    public EliteEnemyMoveState MoveState { get; private set; }
    public EliteEnemyDetectedState DetectedState { get; private set; }
    public EliteEnemyMeleeAttackState MeleeAttackState { get; private set; }
    public EliteEnemyRangedAttackState RangedAttackState { get; private set; }
    public EliteEnemyTeleportState TeleportState { get; private set; }
    
    public EliteEnemySpinState SpinState { get; private set; }
    #endregion

    #region Data

    [SerializeField] private D_IdleState _idleData;
    [SerializeField] private D_MoveState _moveData;
    [SerializeField] private D_PlayerDetected _detectedData;
    [SerializeField] private D_MeleeAttack _meleeAttackData;
    [SerializeField] private D_RangedAttack _rangedAttackData;
    [SerializeField] private D_TeleportState _teleportData;
    [SerializeField] private Transform _attackTransform;
    #endregion

    #region UNITYCALLBACKS

    public override void Start()
    {
        base.Start();

        IdleState = new EliteEnemyIdleState(this, _finiteStateMachine, "idle", _idleData, this);
        MoveState = new EliteEnemyMoveState(this, _finiteStateMachine, "move", _moveData, this);
        DetectedState = new EliteEnemyDetectedState(this, _finiteStateMachine, "playerDetected", _detectedData,this);
        MeleeAttackState = new EliteEnemyMeleeAttackState(this, _finiteStateMachine, "melee",_attackTransform ,_meleeAttackData, this);
        RangedAttackState = new EliteEnemyRangedAttackState(this, _finiteStateMachine, "ranged", _attackTransform,
            _rangedAttackData, this);
        TeleportState = new EliteEnemyTeleportState(this, _finiteStateMachine, "teleport",_teleportData ,this);
        _finiteStateMachine.Initialize(IdleState);
    }

    #endregion
}
