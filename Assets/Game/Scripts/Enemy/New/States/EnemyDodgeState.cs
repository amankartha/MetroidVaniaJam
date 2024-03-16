using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodgeState : EnemyState
{
    protected D_DodgeState _stateData;

    protected bool performCloseRangeAction;
    protected bool isPlayerInMaxAggroRange;

    protected bool isGrounded;
    protected bool isDodgeOver;
    public EnemyDodgeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_DodgeState dodgeState) : base(entity, stateMachine, animBoolName)
    {
        _stateData = dodgeState;
    }

    public override void Enter()
    {
        base.Enter();
        isDodgeOver = false;
        _entity.SetVelocity(_stateData.DodgeSpeed,_stateData.DodgeAngle,-_entity.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= _startTime + _stateData.DodgeTime && isGrounded)
        {
            isDodgeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        performCloseRangeAction = _entity.CheckPlayerInCloseRangeAction();
        isPlayerInMaxAggroRange = _entity.CheckPlayerInMaxAggroRange();

        isGrounded = _entity.CheckGround();
    }
}
