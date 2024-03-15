using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyPlayerDetectedState : EnemyPlayerDetectedState
{
    private ShieldEnemy _enemy;

    protected bool isDetectingLedge;
    
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
        if (performLongRangeAction)
        {
            _stateMachine.ChangeState(_enemy.ChargeState);
        }
        else if (!isDetectingLedge)
        {
            _entity.Flip();
            _stateMachine.ChangeState(_enemy.moveState);
        }
       /* else if (!isPlayerInMaxAggroRange)
        {
            _stateMachine.ChangeState(_enemy.LookForPlayerState);
        }*/
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isDetectingLedge = _entity.CheckLedge();
    }
}
