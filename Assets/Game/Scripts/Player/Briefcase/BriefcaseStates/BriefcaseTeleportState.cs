using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefcaseTeleportState : BriefcaseState
{
    

    public BriefcaseTeleportState(Briefcase briefcase, BriefcaseStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(briefcase, stateMachine, playerData, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        GameManager.Instance.goMainPlayer.transform.parent = null;
        GameManager.Instance.goMainPlayer.transform.position =  _briefcase.transform.position; 
        GameManager.Instance.PlayerScript.PauseGravity(_playerData.teleportPauseGravityDuration);
      
    }

    public override void Exit()
    {
        base.Exit();
       
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        TeleportDelay();
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

    public void TeleportDelay()
    {
        if (Time.time > _startTime + _playerData.teleportDelay)
        {
            _stateMachine.ChangeState(_briefcase.IdleState);
        }
    }
}
