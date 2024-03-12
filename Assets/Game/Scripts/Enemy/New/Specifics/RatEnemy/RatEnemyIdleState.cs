using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemyIdleState : EnemyIdleState
{
    private RatEnemy _enemy;
    
    public RatEnemyIdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState idleState,RatEnemy ratEnemy) : base(entity, stateMachine, animBoolName, idleState)
    {
        _enemy = ratEnemy;
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
        if (isIdleTimeOver)
        {
            _stateMachine.ChangeState(_enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
