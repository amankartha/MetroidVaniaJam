using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeEnemyMoveState : EnemyMoveState
{
    private CoffeeEnemy _enemy;

    public CoffeeEnemyMoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData,CoffeeEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if (isDetectingWall || !isDetectingLedge)
        {
            _enemy.IdleState.SetFLipAfterIdle(true);
            _stateMachine.ChangeState(_enemy.IdleState);
        }
        else if (isPlayerInMinAggroRange)
        {
            _stateMachine.ChangeState(_enemy.DetectedState);
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
