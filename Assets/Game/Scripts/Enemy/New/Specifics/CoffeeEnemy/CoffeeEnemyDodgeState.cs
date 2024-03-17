using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeEnemyDodgeState : EnemyDodgeState
{
   

    private CoffeeEnemy _enemy;
    public CoffeeEnemyDodgeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DodgeState dodgeState,CoffeeEnemy enemy) : base(entity, stateMachine, animBoolName, dodgeState)
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
        if (isDodgeOver)
        {
            if (performCloseRangeAction)
            {
                _stateMachine.ChangeState(_enemy.DetectedState);
            }
            else if (isPlayerInMaxAggroRange && !performCloseRangeAction)
            {
                //TODO:MELEE??
                _stateMachine.ChangeState(_enemy.RangedAttackState);
            }
            else if(!isPlayerInMaxAggroRange)
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
}
