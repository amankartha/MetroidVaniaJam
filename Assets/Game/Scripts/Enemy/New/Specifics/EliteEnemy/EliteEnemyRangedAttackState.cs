using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemyRangedAttackState : EnemyRangedAttackState
{
    private EliteEnemy _enemy;
    public EliteEnemyRangedAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttack attack,EliteEnemy enemy) : base(etity, stateMachine, animBoolName, attackPosition, attack)
    {
        _enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
