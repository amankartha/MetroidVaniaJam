using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedState : PlayerState
{
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
