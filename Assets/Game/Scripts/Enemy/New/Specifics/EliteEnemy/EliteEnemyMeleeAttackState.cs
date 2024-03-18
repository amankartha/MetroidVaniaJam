using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemyMeleeAttackState : EnemyMeleeAttackState
{
    private EliteEnemy _enemy;

    public EliteEnemyMeleeAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack data,EliteEnemy enemy) : base(etity, stateMachine, animBoolName, attackPosition, data)
    {
        this._enemy = enemy;
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

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
