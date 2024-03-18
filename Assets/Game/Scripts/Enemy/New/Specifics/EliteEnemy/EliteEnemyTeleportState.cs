using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemyTeleportState : EnemyTeleportState
{
    private EliteEnemy _enemy;
    
    public Vector3 startPos;
    public bool shouldRecover = false;
    public EliteEnemyTeleportState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_TeleportState data,EliteEnemy enemy) : base(entity, stateMachine, animBoolName, data)
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
        shouldRecover = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (shouldRecover)
        {
            _enemy._finiteStateMachine.ChangeState(_enemy.RecoveryState);
        }
        else if (RecoveryTimer())
        {
           _enemy._finiteStateMachine.ChangeState(_enemy.SpinState);
        }
    }

    public override void SetTeleportPos(Vector3 pos)
    {
        base.SetTeleportPos(pos);
        _enemy.RangedAttackState.shouldTeleport = true;
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
