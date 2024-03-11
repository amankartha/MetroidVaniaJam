using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool _isGrounded;
    private bool _isTouchingWall;
    private bool _isTouchingWallBack;
    private bool _oldIsTouchingWall;
    private bool _oldIsTouchingWallBack;
    private int _aerialXInput;
    private bool _jumpInput;
    private bool _coyoteTime;
    private bool _wallJumpCoyoteTime;
    private bool _isJumping;
    private bool _jumpInputStop;
    private bool _isTouchingLegde;
    private bool _dodgeInput;
    private bool _throwInput;
    private float _startWallJumpCoyoteTime;
    
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
        CheckWallJumpCoyoteTime();
        _aerialXInput = _player.InputHandler.NormInputX;
        _jumpInput = _player.InputHandler.JumpInput;
        _jumpInputStop = _player.InputHandler.JumpInputStop;
        _dodgeInput = _player.InputHandler.DodgeInput;
        _throwInput = _player.InputHandler.ThrowInput;
         CheckJumpMultipler();
        

         if (_isGrounded && _player.CurrentVelocity.y < 0.01f)
        {
            _stateMachine.ChangeState(_player.LandState);
        }
        else if (_isTouchingWall && !_isTouchingLegde && !_isGrounded)
        {
            _stateMachine.ChangeState(_player.LedgeClimbState);
        }
         else if(_throwInput && _player.BriefcaseScript._isBriefcaseInHand  && _player.CheckIfCanThrow())
         {
             _stateMachine.ChangeState(_player.ThrowState);
         }
         else if (_jumpInput && (_isTouchingWall || _isTouchingWallBack))
        {
            _isTouchingWall = _player.CheckIfTouchingWall();
            _player.WallJumpState.DetermineWallJumpDirection(_isTouchingWall);
            _stateMachine.ChangeState(_player.WallJumpState);
        }
        else  if (_jumpInput && _player.JumpState.CanJump())
        {
            
            _coyoteTime = false;
            _player.InputHandler.UseJumpInput();
            _stateMachine.ChangeState(_player.JumpState);
        }
        else if (_isTouchingWall && _aerialXInput == _player.FacingDirection && _player.CurrentVelocity.y <= 0) 
        {
            _stateMachine.ChangeState(_player.WallSlideState);
        }
        else
        {
            _player.CheckIfShouldFlip(_aerialXInput);
            _player.SetVelocityX(_playerData.aerialVelocity * _aerialXInput);
            StopWallJumpCoyoteTime();
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
        _oldIsTouchingWall = _isTouchingWall;
        _oldIsTouchingWallBack = _isTouchingWallBack;
        _isGrounded = _player.CheckIfGrounded();
        _isTouchingWall = _player.CheckIfTouchingWall();
        _isTouchingWallBack = _player.CheckIfTouchingWallBack();
        _isTouchingLegde = _player.CheckIfTouchingLedge();

        if (_isTouchingWall && !_isTouchingLegde)
        {
            _player.LedgeClimbState.SetDetectedPosition(_player.transform.position);
        }
        if (!_wallJumpCoyoteTime && !_isTouchingWall && !_isTouchingWallBack &&
            (_oldIsTouchingWall || _oldIsTouchingWallBack))
        {
            StartWallJumpCoyoteTime();
        }
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

    public override void Exit()
    {
        base.Exit();
        _oldIsTouchingWall = false;
        _oldIsTouchingWallBack = false;
        _isTouchingWall = false;
        _isTouchingWallBack = false;
    }

    private void CheckCoyoteTime()
    {
        if (_coyoteTime && Time.time > _startTime + _playerData.coyoteTime)
        {
            _coyoteTime = false;
            _player.JumpState.DecreaseAmountOfJumpsLeft();
        }
            
    }

    private void CheckWallJumpCoyoteTime()
    {
        if (_wallJumpCoyoteTime && Time.time > _startWallJumpCoyoteTime + _playerData.coyoteTime)
        {
            _wallJumpCoyoteTime = false;
        }
    }

    public void SetIsJumping() => _isJumping = true;

    public void StartWallJumpCoyoteTime()
    {
        _wallJumpCoyoteTime = true;
        _startWallJumpCoyoteTime = Time.time;
    }

    public void StopWallJumpCoyoteTime() => _wallJumpCoyoteTime = false;
    public void StartCoyoteTime() => _coyoteTime = true;
}
