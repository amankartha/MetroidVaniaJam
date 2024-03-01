using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{
    private int _wallJumpDirection;
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");
    private static readonly int XVelocity = Animator.StringToHash("xVelocity");

    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        _player.InputHandler.UseJumpInput();
        _player.JumpState.ResetAmountOfJumpsLeft();
        _player.SetVelocity(_playerData.wallJumpVelocity,_playerData.wallJumpAngle,_wallJumpDirection);
        _player.CheckIfShouldFlip(_wallJumpDirection);
        _player.JumpState.DecreaseAmountOfJumpsLeft();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _player.Anim.SetFloat(YVelocity,_player.CurrentVelocity.y);
        _player.Anim.SetFloat(XVelocity,_player.CurrentVelocity.x);

        if (Time.time >= _startTime + _playerData.wallJumpTime)
        {
            _isAbilityDone = true;
        }
    }

    public void DetermineWallJumpDirection(bool isTouchingWall)
    {
        if (isTouchingWall)
        {
            _wallJumpDirection = -_player.FacingDirection;
        }
        else
        {
            _wallJumpDirection = -_player.FacingDirection;
        }
    }
}
