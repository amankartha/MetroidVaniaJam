using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetectedState : EnemyState
{
    protected D_PlayerDetected stateData;
    protected bool isPlayerInMinAggroRange;
    protected bool isPlayerInMaxAggroRange;

    public EnemyPlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_PlayerDetected stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        isPlayerInMinAggroRange = _entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = _entity.CheckPlayerInMaxAggroRange();
        _entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        isPlayerInMinAggroRange = _entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = _entity.CheckPlayerInMaxAggroRange();
    }
}
