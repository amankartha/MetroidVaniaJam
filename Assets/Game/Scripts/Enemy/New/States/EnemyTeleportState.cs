using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleportState : EnemyState
{
    protected D_TeleportState _stateData;
    protected Vector3 _teleportPosition;
    public EnemyTeleportState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_TeleportState data) : base(entity, stateMachine, animBoolName)
    {
        _stateData = data;
    }

    public override void Enter()
    {
        base.Enter();
        _entity.gameObject.transform.position = _teleportPosition;
    }

    public override void Exit()
    {
        base.Exit();
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

    public void SetTeleportPos(Vector3 pos)
    {
        _teleportPosition = pos;
    }

    public bool RecoveryTimer()
    {
        if (Time.time >= _startTime + _stateData.teleportRecovery)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
