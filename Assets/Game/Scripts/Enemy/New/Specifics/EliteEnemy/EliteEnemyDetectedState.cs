using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemyDetectedState : EnemyPlayerDetectedState
{
    private EliteEnemy _enemy;

    public EliteEnemyDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData,EliteEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if (performCloseRangeAction)
        {
            _stateMachine.ChangeState(_enemy.MeleeAttackState);
        }
        else if(performLongRangeAction)
        {
            _stateMachine.ChangeState(_enemy.RangedAttackState);
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
