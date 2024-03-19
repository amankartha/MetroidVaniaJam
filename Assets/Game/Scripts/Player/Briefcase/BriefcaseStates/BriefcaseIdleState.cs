using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BriefcaseIdleState : BriefcaseState
{
    
    public BriefcaseIdleState(Briefcase briefcase, BriefcaseStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(briefcase, stateMachine, playerData, animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        _briefcase.SetVelocityZero();
        _briefcase._isBriefcaseInHand = true;
        _briefcase.Anim.ResetTrigger("TransitionToReturnThrow");
        _briefcase.Anim.ResetTrigger("TransitionToIdleThrow");
        _briefcase.TriggerCollider.enabled = false;
        if (GameManager.Instance.PlayerScript.hasAbility1)
        {
            GameManager.Instance.PlayerScript.briefcaseGameObject.SetActive(true);
        }

        GameManager.Instance.OnThrowIconChange?.Invoke();
    }

    public override void Exit()
    {
        base.Exit();
        _briefcase._isBriefcaseInHand = false;
        _briefcase.TriggerCollider.enabled = true;
        GameManager.Instance.OnThrowIconChange?.Invoke();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _briefcase.RB.position = _briefcase._initTransform.position;
        
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
}
