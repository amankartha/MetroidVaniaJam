using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Player.Briefcase;
using UnityEngine;

public class BriefcaseReturnState : BriefcaseState

{
    public BriefcaseReturnState(Briefcase briefcase, BriefcaseStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(briefcase, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _briefcase.ColliderSettings(false);
        _briefcase.SetVelocity( 30f,_briefcase._initTransform.position  - _briefcase.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CheckDistance();
        
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

    public void CheckDistance()
    {
        Vector2 distance = _briefcase._initTransform.position - _briefcase.transform.position;
        _briefcase.SetVelocity( _playerData.throwVelocity,distance);
        if (distance.magnitude < 0.5f )
        {
            _briefcase.Animator.SetTrigger("TransitionToReturnThrow");
            _briefcase.ColliderSettings(true);  
            _briefcase.StateMachine.ChangeState(_briefcase.IdleState);
            
        }
    }
   
}