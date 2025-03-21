using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeEnemyDetectedState : EnemyPlayerDetectedState
{
    private CoffeeEnemy _enemy;
    public CoffeeEnemyDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData,CoffeeEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        _enemy = enemy;
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
        if (!isPlayerInMaxAggroRange)
        {
            _stateMachine.ChangeState(_enemy.LookForPlayerState);
        }
        else if (performCloseRangeAction && Time.time >= _enemy.DodgeState._startTime + _enemy.dodgeStateData.DodgeCooldown )
        {
            if (!isLedgeBehind|| isWallBehind)
            {
                _enemy.DodgeState.useExtendedDodge = true;
                _stateMachine.ChangeState(_enemy.DodgeState);
            }
            else
            {
                _stateMachine.ChangeState(_enemy.DodgeState);
            }
        }
        else if (performLongRangeAction && !performCloseRangeAction && Time.time >= _enemy.RangedAttackState._startTime + _enemy.RangedAttackState._stateData.cooldown)
        {
            _stateMachine.ChangeState(_enemy.RangedAttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        performLongRangeAction = _entity.CheckPlayerInLongRangeAction();
    }

}
