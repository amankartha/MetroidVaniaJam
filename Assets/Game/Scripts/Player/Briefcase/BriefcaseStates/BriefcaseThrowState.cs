using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefcaseThrowState : BriefcaseState

{
    public BriefcaseThrowState(Briefcase briefcase, BriefcaseStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(briefcase, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _briefcase.SetVelocityX(_playerData.throwVelocity * GameManager.Instance.PlayerScript.FacingDirection);
        _briefcase.ColliderSettings(true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    
        if (GameManager.Instance.PlayerScript.InputHandler.ThrowInput && GameManager.Instance.PlayerScript.hasAbility2)
        {
            _stateMachine.ChangeState(_briefcase.TeleportState);
        }
        CheckReturnTime();    
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

    private void CheckReturnTime()
    {
        if (Time.time > _startTime + _playerData.throwMaxDuration)
        {
            _briefcase.Anim.SetTrigger("TransitionToIdleThrow");
            _briefcase.StateMachine.ChangeState(_briefcase.IdleRotateState);
        }
    }
}
