using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyMoveState : EnemyMoveState
{
    private ShieldEnemy _enemy;
    
    
    
    
    
    public ShieldEnemyMoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData,ShieldEnemy shieldEnemy) : base(entity, stateMachine, animBoolName, stateData)
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
