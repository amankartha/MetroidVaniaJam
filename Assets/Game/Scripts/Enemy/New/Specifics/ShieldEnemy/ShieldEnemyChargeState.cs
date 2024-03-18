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
        ShieldEnemy.chargeParticles.Play();
    }

    public override void Exit()
    {
        base.Exit();
        ShieldEnemy.chargeParticles.Stop();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isDetectingLedge || isDetectingWall)
        {
            _stateMachine.ChangeState(ShieldEnemy.StunState);
        }
        else if (isChargeTimeOver)
        {
            if (isPlayerInMinAggroRange)
            {
                _stateMachine.ChangeState(ShieldEnemy.StunState);
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
