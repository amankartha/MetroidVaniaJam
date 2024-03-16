using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodgeState : EnemyState
{
    protected D_DodgeState _stateData;

    protected bool performCloseRangeAction;
    protected bool isPlayerInMaxAggroRange;

    protected bool isGrounded;
    protected bool isDodgeOver;
    public bool useExtendedDodge = false;
    public EnemyDodgeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_DodgeState dodgeState) : base(entity, stateMachine, animBoolName)
    {
        _stateData = dodgeState;
    }

    public override void Enter()
    {
        base.Enter();
        if (useExtendedDodge)
        {
            Debug.Log("USED EXTENDED DODGFE");
            isDodgeOver = false;
            _entity.Flip();
            _entity.SetVelocity(_stateData.DodgeSpeed * 1.5f ,_stateData.DodgeAngle,-_entity.FacingDirection);
        }
        else
        {
            isDodgeOver = false;
            _entity.SetVelocity(_stateData.DodgeSpeed,_stateData.DodgeAngle,-_entity.FacingDirection);
            
        }
        Physics2D.IgnoreCollision(_entity._boxCollider2D,GameManager.Instance.PlayerScript.BoxCollider2D,true);    
        useExtendedDodge = false;   

    }

    public override void Exit()
    {
        base.Exit();
        Physics2D.IgnoreCollision(_entity._boxCollider2D,GameManager.Instance.PlayerScript.BoxCollider2D,false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= _startTime + _stateData.DodgeTime && isGrounded)
        {
            isDodgeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        performCloseRangeAction = _entity.CheckPlayerInCloseRangeAction();
        isPlayerInMaxAggroRange = _entity.CheckPlayerInMaxAggroRange();

        isGrounded = _entity.CheckGround();
    }
}
