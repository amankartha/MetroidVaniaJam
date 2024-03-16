using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttackState : AttackState
{
    public D_RangedAttack _stateData;
    protected GameObject projectile;
    protected Projectile ProjectileScript;
    public EnemyRangedAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition,D_RangedAttack attack) : base(etity, stateMachine, animBoolName, attackPosition)
    {
        _stateData = attack;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        projectile = GameObject.Instantiate(_stateData.Projectile,attackPosition.position,attackPosition.rotation);
        ProjectileScript = projectile.GetComponent<Projectile>();
        ProjectileScript.SetValues(_stateData.duration,_stateData.Damage);
        ProjectileScript.ShootProjectile(GameManager.Instance.tMainPlayer.position);
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
