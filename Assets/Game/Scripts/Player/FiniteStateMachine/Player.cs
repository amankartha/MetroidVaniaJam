using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{

    #region STATES

    public PlayerStateMachine StateMachine { get; private set; }
    
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    
    public PlayerJumpState JumpState { get; private set; }
    
    public PlayerInAirState InAirState { get; private set; }
    
    public PlayerLandState LandState { get; private set; }
    
    public PlayerWallGrabState WallGrabState { get; private set; }
    
    public PlayerWallSlideState WallSlideState { get; private set; }
    
    public PlayerWallJumpState WallJumpState { get; private set; }
    
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }

    #endregion

    #region COMPONENTS

    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    [SerializeField] 
    private PlayerData _playerData;

    private Vector2 workspace;

    #endregion

    #region CHECKTRANSFORMS

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private Transform _ledgeCheck;

    #endregion
    
    #region UNITYCALLBACKS

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this,StateMachine,_playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, _playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, _playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, _playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, _playerData, "land");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, _playerData, "wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, _playerData, "wallGrab");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, _playerData, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, _playerData, "ledgeClimbState");

    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        FacingDirection = 1;
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

    #endregion

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

    public void SetVelocity(float velocity,Vector2 angle,int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction,angle.y * velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _playerData.groundCheckRadius, _playerData.groundLayer);
    }

    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(_wallCheck.position, Vector2.right * FacingDirection, _playerData.wallCheckDistance,
            _playerData.groundLayer);
    }
    public bool CheckIfTouchingLedge()
    {
        return Physics2D.Raycast(_ledgeCheck.position, Vector2.right * FacingDirection, _playerData.wallCheckDistance,
            _playerData.groundLayer);
    }
    public bool CheckIfTouchingWallBack()
    {
        return Physics2D.Raycast(_wallCheck.position, Vector2.right * -FacingDirection, _playerData.wallCheckDistance,
            _playerData.groundLayer);
    }


    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    
    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public Vector2 DetermineCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(_wallCheck.position, Vector2.right * FacingDirection,
            _playerData.wallCheckDistance, _playerData.groundLayer);
        float xDistance = xHit.distance;
        workspace.Set(xDistance * FacingDirection, 0f);
        RaycastHit2D yHit = Physics2D.Raycast(_ledgeCheck.position + (Vector3)(workspace), Vector2.down,
            _ledgeCheck.position.y - _wallCheck.position.y, _playerData.groundLayer);
        float yDistance = yHit.distance;
        workspace.Set(_wallCheck.position.x + xDistance * FacingDirection, _ledgeCheck.position.y - yDistance);
        return workspace;
    }
}
