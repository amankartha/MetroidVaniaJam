using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool _isGrounded;
    private int _aerialXInput;
    private bool _jumpInput;

    #region CACHE

    private static readonly int XVelocity = Animator.StringToHash("xVelocity");
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");

    #endregion

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
       
        _aerialXInput = _player.InputHandler.NormInputX;
        _jumpInput = _player.InputHandler.JumpInput;
        if (_isGrounded && _player.CurrentVelocity.y < 0.01f)
        {
            _stateMachine.ChangeState(_player.LandState);
        }else if (_jumpInput && _player.JumpState.CanJump())
        {
            _stateMachine.ChangeState(_player.JumpState);
        }
        else
        {
            _player.CheckIfShouldFlip(_aerialXInput);
            _player.SetVelocityX(_playerData.aerialVelocity * _aerialXInput);
            
            _player.Anim.SetFloat(YVelocity,_player.CurrentVelocity.y);
            _player.Anim.SetFloat(XVelocity,Mathf.Abs(_player.CurrentVelocity.x));
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
