using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyStunState : EnemyStunState
{
    private ShieldEnemy Enemy;
    private bool isDetectingLedge;
    public ShieldEnemyStunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData,ShieldEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.Enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        Enemy.DisableCollider();
        Enemy.SetVelocity(0);
    }

    public override void Exit()
    {
        base.Exit();
        Enemy.EnableCollider();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isStunTimeOver)
        {
            if (!isDetectingLedge)
            {
                _entity.Flip();
                _stateMachine.ChangeState(Enemy.moveState);
            }
            else if (isPlayerInMinAgroRange)
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
        isDetectingLedge = _entity.CheckLedge();
    }
}
