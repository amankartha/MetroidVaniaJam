using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeEnemyStunState : EnemyStunState
{
    private CoffeeEnemy _enemy;

    public CoffeeEnemyStunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData,CoffeeEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if (isStunTimeOver)
        {
            if (isPlayerInMinAgroRange)
            {
                _stateMachine.ChangeState(_enemy.DetectedState);
            }
            else
            {
                _stateMachine.ChangeState(_enemy.LookForPlayerState);
            }
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
