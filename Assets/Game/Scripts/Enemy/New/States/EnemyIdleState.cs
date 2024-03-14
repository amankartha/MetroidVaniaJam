using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{

    protected D_IdleState stateData;

    protected bool _flipAfteridle;
    protected bool isIdleTimeOver;
    protected bool isPlayerInMinAggroRange;

    public float idleTime;
    
    public EnemyIdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_IdleState idleState) : base(entity, stateMachine, animBoolName)
    {
        stateData = idleState;
    }


    public override void Enter()
    {
        base.Enter();
        _entity.SetVelocity(0f);
        isIdleTimeOver = false;
        SetRandomIdleTime();
       
    }

    public override void Exit()
    {
        base.Exit();

        if (_flipAfteridle)
        {
            _entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time > _startTime + idleTime)
        {
            isIdleTimeOver = true;
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
       
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAggroRange = _entity.CheckPlayerInMinAggroRange();
    }

    public void SetFLipAfterIdle(bool flip)
    {
        _flipAfteridle = flip;
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.MaxIdleTime);
    }
}
