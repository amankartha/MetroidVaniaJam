using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        _player.InputHandler.UseAttackInput();
        _player.PauseGravity(0.2f);
       
        
    }

    public override void Exit()
    {
        base.Exit();
        
        _player.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        _player.SetVelocityX(_playerData.attackVelocity * _player.FacingDirection);
        base.LogicUpdate();
        
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
        _player.DealDamage();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
     
        _isAbilityDone = true;
    }
}
