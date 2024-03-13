using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine _finiteStateMachine;


    public D_Entity EntityData;
    public int FacingDirection { get; private set; }

    private Vector2 velocityWorkspace;
    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }
    [field:SerializeField]public GameObject AliveGo { get; private set; }

    private EnemyHealth _enemyHealth;

    [SerializeField] 
    private Transform WallCheck;

    [SerializeField] 
    private Transform LedgeCheck;
    public virtual void Start()
    {
        FacingDirection = 1;
        RB = AliveGo.GetComponent<Rigidbody2D>();
        Anim = AliveGo.GetComponent<Animator>();
        _enemyHealth = AliveGo.GetComponent<EnemyHealth>();
        _finiteStateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        _finiteStateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        _finiteStateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(FacingDirection * velocity,RB.velocity.y);
        RB.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(WallCheck.position, AliveGo.transform.right, EntityData.WallCheckDistance,
            EntityData.GroundLayer);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(LedgeCheck.position,Vector2.down,EntityData.LedgeCheckDistance,EntityData.GroundLayer);
    }

    public virtual void Flip()
    {
        FacingDirection *= -1;
        AliveGo.transform.Rotate(0f,180f,0f);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(WallCheck.position, WallCheck.position + (Vector3)(Vector2.right * FacingDirection * EntityData.WallCheckDistance));
        Gizmos.DrawLine(LedgeCheck.position,LedgeCheck.position + (Vector3)(Vector2.down * EntityData.LedgeCheckDistance));
    }
}
