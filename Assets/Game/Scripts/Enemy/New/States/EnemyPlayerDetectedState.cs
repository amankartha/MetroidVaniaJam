using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetectedState : EnemyState
{
    protected D_PlayerDetected stateData;
    protected bool isPlayerInMinAggroRange;
    protected bool isPlayerInMaxAggroRange;

    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;

    public EnemyPlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_PlayerDetected stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        performLongRangeAction = false;
        performCloseRangeAction = false;
        _entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= _startTime + stateData.longRangeActionTime)
        {
            performLongRangeAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
       
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAggroRange = _entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = _entity.CheckPlayerInMaxAggroRange();
        performCloseRangeAction = _entity.CheckPlayerInCloseRangeAction();
        performLongRangeAction = _entity.CheckPlayerInLongRangeAction();
    }
}
