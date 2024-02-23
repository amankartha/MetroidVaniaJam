using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool _isGrounded;
    private int _aerialXInput;
    private bool _jumpInput;
    private bool _coyoteTime;
    private bool _isJumping;
    private bool _jumpInputStop;
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
        
        CheckCoyoteTime();
       
        _aerialXInput = _player.InputHandler.NormInputX;
        _jumpInput = _player.InputHandler.JumpInput;
        _jumpInputStop = _player.InputHandler.JumpInputStop;

         CheckJumpMultipler();
        
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

    private void CheckJumpMultipler()
    {
        if (_isJumping)
        {
            if (_jumpInputStop)
            {
                _player.SetVelocityY(_player.CurrentVelocity.y * _playerData.variableJumpHeightMultiplier );
                _isJumping = false;
            }
            else if(_player.CurrentVelocity.y <=0f)
            {
                _isJumping = false;
            }
        }
    }
    
    private void CheckCoyoteTime()
    {
        if (_coyoteTime && Time.time > _startTime + _playerData.coyoteTime)
        {
            _coyoteTime = false;
            _player.JumpState.DecreaseAmountOfJumpsLeft();
        }
            
    }

    public void SetIsJumping() => _isJumping = true;
    public void StartCoyoteTime() => _coyoteTime = true;
}
