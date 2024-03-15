using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeEnemy : Entity
{
    #region STATES

    public CoffeeEnemyMoveState MoveState { get; private set; }
    public CoffeeEnemyIdleState IdleState { get; private set; }

    #endregion

    #region Data

    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_IdleState idleStateData;

    #endregion


    public override void Start()
    {
        base.Start();
        MoveState = new CoffeeEnemyMoveState(this, _finiteStateMachine,"move", moveStateData, this);
        IdleState = new CoffeeEnemyIdleState(this, _finiteStateMachine, "idle", idleStateData, this);
        
        _finiteStateMachine.Initialize(MoveState);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void ResetStunReistance()
    {
        base.ResetStunReistance();
    }

    public override void Damaged()
    {
        base.Damaged();
    }

    public override void SetVelocity(float velocity)
    {
        base.SetVelocity(velocity);
    }

    public override void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        base.SetVelocity(velocity, angle, direction);
    }

    public override int GetDamageDirection()
    {
        return base.GetDamageDirection();
    }

    public override void Respawn()
    {
        base.Respawn();
    }

    public override bool CheckWall()
    {
        return base.CheckWall();
    }

    public override bool CheckGround()
    {
        return base.CheckGround();
    }

    public override bool CheckLedge()
    {
        return base.CheckLedge();
    }

    public override bool CheckPlayerInMinAggroRange()
    {
        return base.CheckPlayerInMinAggroRange();
    }

    public override bool CheckPlayerInMaxAggroRange()
    {
        return base.CheckPlayerInMaxAggroRange();
    }

    public override void Flip()
    {
        base.Flip();
    }
}
