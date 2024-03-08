using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

using UnityEngine;

public class Briefcase : MonoBehaviour
{
    [SerializeField] private Player _player;
    private BoxCollider2D _boxCollider2D;
    [SerializeField] private PlayerData _playerData;
    private Sequence _throwSequence;
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }

    public Transform _initTransform;
    public bool _isBriefcaseInHand;
    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 workspace;
    #region STATES
    public BriefcaseStateMachine StateMachine { get; private set; }
    public BriefcaseIdleState IdleState { get; private set; }
    public BriefcaseThrowState ThrowState { get; private set; }
    public BriefcaseIdleRotateState IdleRotateState { get;private set; }
    public BriefcaseReturnState ReturnState { get; private set; }
    public BriefcaseTeleportState TeleportState { get; private set; }
    #endregion

    private void Awake()
    {
        StateMachine = new BriefcaseStateMachine();
        IdleState = new BriefcaseIdleState(this, StateMachine, _playerData, "idle");
        ThrowState = new BriefcaseThrowState(this, StateMachine, _playerData, "throw");
        IdleRotateState = new BriefcaseIdleRotateState(this, StateMachine, _playerData, "throw");
        ReturnState = new BriefcaseReturnState(this, StateMachine, _playerData, "throw");
        TeleportState = new BriefcaseTeleportState(this, StateMachine, _playerData, "teleport");
    }

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        
     
        _isBriefcaseInHand = true;
        StateMachine.Initialize(IdleState);
    }
    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
        
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityZero()
    {
        RB.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }
  
    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x,velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocity(float velocity,Vector2 angle)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity ,angle.y * velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void ColliderSettings(bool state)
    {
        _boxCollider2D.enabled = state;
    }

   

    public void ReturnToCharacter()
    {
     
    }

    public void ThrowBriefcase()
    {
        _player.SetThrowFalse();
        StateMachine.ChangeState(ThrowState);
    }

    private void ReturnHelper(Tweener tweener)
    {
        
       
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (_playerData.briefcaseReturnLayer == ( _playerData.briefcaseReturnLayer| (1 << col.gameObject.layer)))
        {
            Debug.Log("Briefcase hit wall, returning");
            StateMachine.ChangeState(ReturnState);
        }
    }
}
