using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookForPlayerState : EnemyState
{
    protected D_LookingForPlayer stateData;

    protected bool turnImmediately;
    
    protected bool isPlayerInMinAggroRange;
    protected bool isAllTurnsDone;
    protected bool isAllTurnTimeDone;

    protected float lastTurnTime;

    protected int amountOfTurnsDone;
    
    public EnemyLookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_LookingForPlayer stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isAllTurnsDone = false;
        isAllTurnTimeDone = false;
        lastTurnTime = _startTime;
        amountOfTurnsDone = 0;
        _entity.SetVelocity(0);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (turnImmediately)
        {
            _entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
            turnImmediately = false;
        }
        else if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && !isAllTurnsDone)
        {
            _entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }

        if (amountOfTurnsDone >= stateData.AmountOfTurns)
        {
            isAllTurnsDone = true;
        }

        if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && isAllTurnsDone)
        {
            isAllTurnsDone = true;
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

    public void SetTurnImmediately(bool flip)
    {
        turnImmediately = flip;
    }
}
