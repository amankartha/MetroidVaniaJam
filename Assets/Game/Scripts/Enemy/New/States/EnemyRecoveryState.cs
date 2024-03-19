using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRecoveryState : EnemyState
{
    protected D_RecoveryState _stateData;
    
    public EnemyRecoveryState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_RecoveryState data) : base(entity, stateMachine, animBoolName)
    {
        _stateData = data;
    }

    public override void Enter()
    {
        base.Enter();
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
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }
}
