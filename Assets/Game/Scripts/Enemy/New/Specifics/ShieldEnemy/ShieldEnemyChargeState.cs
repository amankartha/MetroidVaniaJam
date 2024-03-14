using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyChargeState : EnemyChargeState
{
    private ShieldEnemy ShieldEnemy;
    
    public ShieldEnemyChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData,ShieldEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        ShieldEnemy = enemy;
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
        if (!isDetectingLedge || isDetectingWall)
        {
            _stateMachine.ChangeState(ShieldEnemy.LookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if (isPlayerInMinAggroRange)
            {
                _stateMachine.ChangeState(ShieldEnemy.PlayerDetectedState);
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
