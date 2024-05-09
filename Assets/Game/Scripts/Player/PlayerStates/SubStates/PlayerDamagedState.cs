using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedState : PlayerState
{
    private int _aerialXInput;
    public PlayerDamagedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
       // _player.TriggerBoxCollider2D.enabled = false;
    }

    public override void Exit()
    {
        base.Exit();
       // _player.TriggerBoxCollider2D.enabled = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CheckDuration();
        _aerialXInput = _player.InputHandler.NormInputX;
        _player.CheckIfShouldFlip(_aerialXInput);
        _player.SetVelocityX(_playerData.aerialVelocity * _aerialXInput);
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        _stateMachine.ChangeState(_player.IdleState);
    }

    public bool CheckDuration()
    {
        if (Time.time > _startTime + _playerData.DamagedInvincibilityDuration)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
