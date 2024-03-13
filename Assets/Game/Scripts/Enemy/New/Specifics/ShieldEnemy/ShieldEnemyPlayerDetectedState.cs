using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyPlayerDetectedState : EnemyPlayerDetectedState
{
    private ShieldEnemy _enemy;
    public ShieldEnemyPlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData,ShieldEnemy shieldEnemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if (!isPlayerInMaxAggroRange)
        {
            _enemy.IdleState.SetFLipAfterIdle(false);
            _stateMachine.ChangeState(_enemy.IdleState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
