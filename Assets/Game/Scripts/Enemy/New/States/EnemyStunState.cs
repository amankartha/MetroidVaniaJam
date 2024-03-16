using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunState : EnemyState
{
    protected D_StunState stateData;

    protected bool isStunTimeOver;
    protected bool isGrounded;
    protected bool isMovementStopped;
    protected bool performCloseRangeAction;
    protected bool isPlayerInMinAgroRange;

    public EnemyStunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        isStunTimeOver = false;
        isMovementStopped = false;
        _entity.SetVelocity(stateData.stunKnockBackSpeed,stateData.stunKnockBackAngle,_entity.GetDamageDirection());
    }

    public override void Exit()
    {
        base.Exit();
        _entity.ResetStunReistance();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= _startTime + stateData.stunTime)
        {
            isStunTimeOver = true;
        }

        if (isGrounded && Time.time >= _startTime + stateData.stunTime && !isMovementStopped)
        {
            isMovementStopped = true;
            _entity.SetVelocity(0);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = _entity.CheckGround();
        isPlayerInMinAgroRange = _entity.CheckPlayerInMinAggroRange();

    }
}
