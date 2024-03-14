using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyStunState : EnemyStunState
{
    private ShieldEnemy Enemy;
    public ShieldEnemyStunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData,ShieldEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.Enemy = enemy;
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
        if (isStunTimeOver)
        {
            if (isPlayerInMinAgroRange)
            {
                _stateMachine.ChangeState(Enemy.ChargeState);
            }
            else
            {
                Enemy.LookForPlayerState.SetTurnImmediately(true);
                _stateMachine.ChangeState(Enemy.LookForPlayerState);
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
