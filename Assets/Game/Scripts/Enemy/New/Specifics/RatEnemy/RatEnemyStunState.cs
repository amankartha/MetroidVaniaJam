using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemyStunState : EnemyStunState
{
    private RatEnemy _enemy;
    private bool isDetectingLedge;
    public RatEnemyStunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData,RatEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.SetVelocity(0f);
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
            if (!isDetectingLedge)
            {
                _entity.Flip();
                _stateMachine.ChangeState(_enemy.moveState);
            }
            else
            {
                _stateMachine.ChangeState(_enemy.IdleState);
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
