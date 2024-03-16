using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected FiniteStateMachine _stateMachine;
    protected Entity _entity;

    public float _startTime { get; protected set; }

    protected string _animBoolName;


    public EnemyState(Entity entity, FiniteStateMachine stateMachine,string animBoolName)
    {
        _entity = entity;
        _stateMachine = stateMachine;
        _animBoolName = animBoolName;
    }


    public virtual void Enter()
    {
        _startTime = Time.time;
        _entity.Anim.SetBool(_animBoolName,true);
        DoChecks();
    }

    public virtual void Exit()
    {
        _entity.Anim.SetBool(_animBoolName,false);
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {
        
    }
    
}
