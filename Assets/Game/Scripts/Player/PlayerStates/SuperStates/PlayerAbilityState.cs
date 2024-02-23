using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool _isAbilityDone;
    protected bool _isGrouneded;
    
    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
        _isAbilityDone = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
       
        if (_isAbilityDone)
        {
            if (_isGrouneded && _player.CurrentVelocity.y < 0.01f)
            {
                _stateMachine.ChangeState(_player.IdleState);
            }
            else
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
        _isGrouneded = _player.CheckIfGrounded();
    }
}
