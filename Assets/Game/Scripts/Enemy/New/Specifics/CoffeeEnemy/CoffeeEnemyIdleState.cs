using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeEnemyIdleState : EnemyIdleState
{
    private CoffeeEnemy _enemy;
    public CoffeeEnemyIdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState idleState,CoffeeEnemy enemy) : base(entity, stateMachine, animBoolName, idleState)
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

        if (isPlayerInMinAggroRange)
        {
            _stateMachine.ChangeState(_enemy.DetectedState);
        }
        else if (isIdleTimeOver)
        {
            _stateMachine.ChangeState(_enemy.MoveState);
        }
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
