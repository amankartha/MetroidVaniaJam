using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMeleeAttackState : AttackState
{
    protected D_MeleeAttack _meleeAttackData;
    public EnemyMeleeAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition,D_MeleeAttack data) : base(etity, stateMachine, animBoolName, attackPosition)
    {
        _meleeAttackData = data;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position,
            _meleeAttackData.attackRadius, _meleeAttackData.playerLayer);

        foreach (var collider2D in detectedObjects)
        {
            Debug.Log("HIT PLAYER");
            if (collider2D.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_meleeAttackData.Damage);
            }
        }
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}
