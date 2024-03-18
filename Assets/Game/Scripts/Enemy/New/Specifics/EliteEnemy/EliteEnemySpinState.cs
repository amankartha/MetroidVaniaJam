using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemySpinState : EnemyState
{
    private EliteEnemy _enemy;
    private D_SpinState _StateData;
    private Quaternion initalRot;
    public EliteEnemySpinState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_SpinState spinState,EliteEnemy enemy) : base(entity, stateMachine, animBoolName)
    {
        _enemy = enemy;
        _StateData = spinState;
    }

    public override void Enter()
    {
        base.Enter();
        initalRot = _enemy.AliveGo.transform.rotation;
    }

    public override void Exit()
    {
        base.Exit();
        _enemy.AliveGo.transform.rotation = initalRot;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        _enemy.AliveGo.transform.Rotate(0,30,0);
        if (SpinDuration())
        {
            _enemy.TeleportState.shouldRecover = true;  
            _enemy.TeleportState.SetTeleportPos(_enemy.TeleportState.startPos);
            _stateMachine.ChangeState(_enemy.TeleportState);
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

    public bool SpinDuration()
    {
        return Time.time > _startTime + _StateData.SpinDuration;
    }
}
