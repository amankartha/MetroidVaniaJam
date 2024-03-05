using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefcaseIdleRotateState : BriefcaseState
{
   

    public BriefcaseIdleRotateState(Briefcase briefcase, BriefcaseStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(briefcase, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _briefcase.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CheckIdleDuration();
        if (GameManager.Instance.PlayerScript.InputHandler.ThrowInput)
        {
            _stateMachine.ChangeState(_briefcase.TeleportState);
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

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public void CheckIdleDuration()
    {
        if (Time.time > _startTime + _playerData.throwIdleDuration)
        {
            _stateMachine.ChangeState(_briefcase.ReturnState);
        }
    }
}
