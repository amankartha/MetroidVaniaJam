using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemySpinState : EnemyState
{
    private EliteEnemy _enemy;
    public EliteEnemySpinState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,EliteEnemy enemy) : base(entity, stateMachine, animBoolName)
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
