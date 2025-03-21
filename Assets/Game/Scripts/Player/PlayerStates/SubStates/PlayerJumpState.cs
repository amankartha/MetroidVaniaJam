using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public int _amountOfJumpsLeft;
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        _amountOfJumpsLeft = playerData.numberOfJumps;
    }

    public override void Enter()
    {
        base.Enter();
        _player.InputHandler.UseJumpInput();
        if (_player.CheckIfGrounded())
        {
            _player.CreateDust();
        }
        //TODO Incase we add more jumps
        if (_amountOfJumpsLeft == 1 )
        {
            _player.SetVelocityY(_playerData.secondJumpVelocity);
        }
        else
        {
            _player.SetVelocityY(_playerData.jumpVelocity);     
        }
        
        _isAbilityDone = true;
        _amountOfJumpsLeft--;
        _player.InAirState.SetIsJumping();

    }

    public bool CanJump()
    {
        
        if (_amountOfJumpsLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetAmountOfJumpsLeft()
    {
        
        _amountOfJumpsLeft = _playerData.numberOfJumps;
    }

    public void DecreaseAmountOfJumpsLeft()
    {
        _amountOfJumpsLeft--;
    }
    
}
