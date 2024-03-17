using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemyRangedAttackState : EnemyRangedAttackState
{
    private EliteEnemy _enemy;
    public bool shouldTeleport;
    public bool shouldGoBackToDetected;
    private PenProjectile _penProjectile;
    public EliteEnemyRangedAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttack attack,EliteEnemy enemy) : base(etity, stateMachine, animBoolName, attackPosition, attack)
    {
        _enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        DetectedTimer();
        
        if (isAnimationFinished)
        {
            if (shouldTeleport)
            {
                _enemy._finiteStateMachine.ChangeState(_enemy.TeleportState);
            }
            else if(shouldGoBackToDetected)
            {
                _enemy._finiteStateMachine.ChangeState(_enemy.DetectedState);
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

    public override void TriggerAttack()
    {
        projectile = GameObject.Instantiate(_stateData.Projectile,attackPosition.position,attackPosition.rotation);
        _penProjectile = projectile.GetComponent<PenProjectile>();
        _penProjectile.SetValuesForPen(_stateData.duration,_stateData.Damage,this._enemy);
        
        _penProjectile.ShootProjectile(GameManager.Instance.tMainPlayer.position);
    }

    public override void Enter()
    {
        base.Enter();
        shouldTeleport = false;
        shouldGoBackToDetected = false; 
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public void DetectedTimer()
    {
        if (Time.time >= Time.time + 3f)
        {
            shouldGoBackToDetected = true;
        }
    }
}
