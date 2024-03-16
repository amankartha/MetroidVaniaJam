using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeState : PlayerAbilityState
{

    private bool _jumpInput;
    public PlayerDodgeState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.InputHandler.UseDodgeInput();
        _player.TriggerBoxCollider2D.enabled = false;
        Physics2D.IgnoreLayerCollision(6,7,false);
        _player.SetVelocityX(_playerData.dodgeVelocityX * _player.FacingDirection);
        
    }

    public override void Exit()
    {
        base.Exit();
        _player.TriggerBoxCollider2D.enabled = true;
        Physics2D.IgnoreLayerCollision(6,7,true);
        _player.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _jumpInput = _player.InputHandler.JumpInput;
        if (_jumpInput && _player.JumpState.CanJump())
        {
            _stateMachine.ChangeState(_player.JumpState);
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
        if (_player.CheckIfGrounded())
        {
            _player.StateMachine.ChangeState(_player.IdleState);
        }
        else
        {
            _player.StateMachine.ChangeState(_player.InAirState);
        }
    }
}
