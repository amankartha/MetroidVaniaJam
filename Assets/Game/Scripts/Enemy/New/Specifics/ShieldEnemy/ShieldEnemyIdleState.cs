using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyIdleState : EnemyIdleState
{
    private ShieldEnemy _enemy;
    
    public ShieldEnemyIdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState idleState,ShieldEnemy shieldEnemy) : base(entity, stateMachine, animBoolName, idleState)
    {
        _enemy = shieldEnemy;
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
