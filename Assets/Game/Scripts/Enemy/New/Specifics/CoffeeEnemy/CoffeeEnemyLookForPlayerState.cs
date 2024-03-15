using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeEnemyLookForPlayerState : EnemyLookForPlayerState
{
    private CoffeeEnemy _enemy;
    public CoffeeEnemyLookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookingForPlayer stateData,CoffeeEnemy enemy ): base(entity, stateMachine, animBoolName, stateData)
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
            _stateMachine.ChangeState(_enemy.DetectedState);
        }
        else if(isAllTurnTimeDone)
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
