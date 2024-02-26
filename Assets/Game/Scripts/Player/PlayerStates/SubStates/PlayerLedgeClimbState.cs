using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{

    private Vector2 _detectedPos;
    private Vector2 _cornerPos;
    private Vector2 _startPos;
    private Vector2 _stopPos;
    private bool _isHanging;
    private bool _isClimbing;
    private int _xInput;
    private int _yInput;
    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    
    public void SetDetectedPosition(Vector2 pos) => _detectedPos = pos;
    public override void Enter()
    {
        base.Enter();
        
        _player.SetVelocityZero();
        _player.transform.position = _detectedPos;
        _cornerPos = _player.DetermineCornerPosition();
        
        _startPos.Set(_cornerPos.x - (_player.FacingDirection * _playerData.startOffset.x),_cornerPos.y - _playerData.startOffset.y);
        _stopPos.Set(_cornerPos.x + (_player.FacingDirection * _playerData.stopOffset.x),_cornerPos.y + _playerData.stopOffset.y);

        _player.transform.position = _startPos;
    }

    public override void Exit()
    {
        base.Exit();
        _isHanging = false;
        if (_isClimbing)
        {
            _player.transform.position = _stopPos;
            _isClimbing = false;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (_isAnimationFinished)
        {
            _stateMachine.ChangeState(_player.IdleState);
        }
        else
        {
            _xInput = _player.InputHandler.NormInputX;
            _yInput = _player.InputHandler.NormInputY;
        
        
            _player.SetVelocityZero();
            _player.transform.position = _startPos;

            if (_xInput == _player.FacingDirection && _isHanging && !_isClimbing)
            {
                _isClimbing = true;
                _player.Anim.SetBool("climbLedge",true);
            }
            else if (_yInput == -1 && _isHanging && !_isClimbing)
            {
                _stateMachine.ChangeState(_player.InAirState);
            }
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

        _isHanging = true;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        _player.Anim.SetBool("climbLedge",false);
    }
}
