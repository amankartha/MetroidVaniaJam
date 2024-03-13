using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    
    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAggroRange;

    protected D_MoveState _stateData;
    
    public EnemyMoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        _stateData = stateData;
    }
    

    public override void Enter()
    {
        base.Enter();
        _entity.SetVelocity(_stateData.movementSpeed);

        isDetectingLedge = _entity.CheckLedge();
        isDetectingWall = _entity.CheckWall();
        isPlayerInMinAggroRange = _entity.CheckPlayerInMinAggroRange();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        isDetectingLedge = _entity.CheckLedge();
        isDetectingWall = _entity.CheckWall();
        isPlayerInMinAggroRange = _entity.CheckPlayerInMinAggroRange();
    }
}

