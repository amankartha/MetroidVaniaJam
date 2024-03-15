using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeEnemyDeadState : EnemyDeadState
{
    private CoffeeEnemy _enemy;
    public CoffeeEnemyDeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData,CoffeeEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        _enemy = enemy;
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
