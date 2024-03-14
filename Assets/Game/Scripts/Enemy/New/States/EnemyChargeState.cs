using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : EnemyState
{
    protected D_ChargeState _stateData;

    protected bool isPlayerInMinAggroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    
    public EnemyChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_ChargeState stateData) : base(entity, stateMachine, animBoolName)
    {
        _stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        
        _entity.SetVelocity(_stateData.ChargeSpeed);
        isChargeTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time > _startTime + _stateData.ChargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
      
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isDetectingLedge = _entity.CheckLedge();
        isDetectingWall = _entity.CheckWall();
        isPlayerInMinAggroRange = _entity.CheckPlayerInMinAggroRange();
    }
}
