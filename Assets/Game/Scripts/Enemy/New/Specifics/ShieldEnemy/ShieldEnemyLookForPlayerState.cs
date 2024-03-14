using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyLookForPlayerState : EnemyLookForPlayerState
{
    private ShieldEnemy _enemy;

    public ShieldEnemyLookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookingForPlayer stateData,ShieldEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this._enemy = enemy;
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
            _stateMachine.ChangeState(_enemy.PlayerDetectedState);
        }
        else if (isAllTurnTimeDone)
        {
            _stateMachine.ChangeState(_enemy.moveState);
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
