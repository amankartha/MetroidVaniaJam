using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{


    protected int _xInput;
    private bool _jumpInput;
    private bool _isGrounded;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        _player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
       _xInput = _player.InputHandler.NormInputX;
       _jumpInput = _player.InputHandler.JumpInput;

       if (_jumpInput && _player.JumpState.CanJump())
       {
           _stateMachine.ChangeState(_player.JumpState);
       }
       else if(!_isGrounded)
       {
           _player.InAirState.StartCoyoteTime();
           _stateMachine.ChangeState(_player.InAirState);
       }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        _isGrounded = _player.CheckIfGrounded();
    }
}
