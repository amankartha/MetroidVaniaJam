using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemyMoveState : EnemyMoveState
{
    private RatEnemy _enemy;

    public RatEnemyMoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData,RatEnemy ratEnemy) : base(entity, stateMachine, animBoolName, stateData)
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
        Debug.Log($"{isDetectingWall} , {!isDetectingLedge}");
        if (isDetectingWall || !isDetectingLedge)
        {
            _enemy.IdleState.SetFLipAfterIdle(true);
            _stateMachine.ChangeState(_enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
