using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeEnemyRangedAttackState : EnemyRangedAttackState
{
    private CoffeeEnemy _enemy;
    
    public CoffeeEnemyRangedAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttack attack,CoffeeEnemy enemy) : base(etity, stateMachine, animBoolName, attackPosition, attack)
    {
        _enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                _stateMachine.ChangeState(_enemy.DetectedState);
            }
            else
            {
                _stateMachine.ChangeState(_enemy.LookForPlayerState);
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

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
