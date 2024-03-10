using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;


public class Player : MonoBehaviour
{
    #region Variables

    private float _throwCooldown;
    private float _throwCooldownTimer;
    public float ThrowCooldownTimer 
    {
        get => _throwCooldownTimer;

        private set
        {
            if (!_canThrow && _throwCooldownTimer <=0)
            {
                _canThrow = true;
                _throwCooldownTimer = _throwCooldown;
            }
            else
            {
                _throwCooldownTimer = value;
                _throwCooldownTimer = Mathf.Clamp(_throwCooldownTimer, 0, 100);    
            }
            
        }
    }
    private bool _canThrow;

    public int MaxPotions { get; set; } 
    private int _potionCount;
    public int PotionCount
    {
        get
        {
            return _potionCount;
        }
        set
        {
            _potionCount = math.clamp(value, 0, MaxPotions);
        }
    }
    
    
    #endregion
    
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
    
    public PlayerDodgeState DodgeState { get; private set; }
    
    public PlayerThrowState ThrowState { get; private set; }

    public PlayerDamagedState DamagedState { get; private set; }

    #endregion

    #region COMPONENTS
    
    
    [field:SerializeField] public PlayerHealth PlayerHealth { get; private set; }
    [field:SerializeField] public HealthBar healthBarUI { get; private set; }

    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    
    [field: SerializeField] public BoxCollider2D BoxCollider2D { get; private set; }
    [field: SerializeField]public BoxCollider2D TriggerBoxCollider2D { get; private set; }

    public ParticleSystem dustPS;
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    [field: SerializeField] public Briefcase BriefcaseScript { get; private set; }
    
    [SerializeField] 
    private PlayerData _playerData;

    private Vector2 workspace;


    #endregion

    #region CHECKTRANSFORMS

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private Transform _ledgeCheck;
    [SerializeField] private Transform _damageCheck;

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
        DodgeState = new PlayerDodgeState(this, StateMachine, _playerData, "dodge");
        ThrowState = new PlayerThrowState(this, StateMachine, _playerData, "throw");
        DamagedState = new PlayerDamagedState(this, StateMachine, _playerData, "damaged");



    }

    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
      
        
        FacingDirection = 1;
        StateMachine.Initialize(IdleState);

        _throwCooldown = _playerData.throwCoolDown;
        ThrowCooldownTimer = _throwCooldown;
        _canThrow = true;
        
        #region Healthstuff

        PlayerHealth.SetHealth(_playerData.PlayerBaseHealth);
        PlayerHealth.HPSection = _playerData.PlayerBaseHPSection;

        MaxPotions = _playerData.InitalPotionCount;

        #endregion
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
        
       
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
        if (!_canThrow && BriefcaseScript._isBriefcaseInHand)
        {
            ThrowCooldownTimer -= Time.fixedDeltaTime;
           
        }
    }

    #endregion

    #region MOVEMENTBASEDMETHODS

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
    public void SetVelocityXY(Vector2 velocity,float powerX,float PowerY)
    {
        velocity.Normalize();
        
        workspace.Set(velocity.x * powerX,velocity.y *PowerY);
        Debug.Log(workspace);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetPosition(Vector2 pos)
    {
        RB.position = pos;
    }


    #endregion

    #region CHECKMETHODS

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
    //TODO CHANGE THESE TO BOXCAST
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

    public bool CheckIfCanThrow()
    {
        return _canThrow;
    }


    #endregion

    #region HEALTHMETHODS

    public void DrinkPotion()
    {
        if (_potionCount > 0)
        {
            PlayerHealth.Heal(_playerData.HPPotionRecoverAmount);
            _potionCount--;
        }
    }

    public void UpdateHealthBarUI()
    {
        healthBarUI.UpgradeHealth();
    }

    #endregion

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    #region HELPERMETHODS

    public void CreateDust()
    {
        dustPS.Play();
    }
    
    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
        if (CheckIfGrounded())
        {
            CreateDust();
        }
    }

    public Vector2 DetermineCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(_wallCheck.position, Vector2.right * FacingDirection,
            _playerData.wallCheckDistance, _playerData.groundLayer);
        float xDistance = xHit.distance;
        workspace.Set(xDistance * FacingDirection, 0f);
        RaycastHit2D yHit = Physics2D.Raycast(_ledgeCheck.position + (Vector3)(workspace), Vector2.down,
            _ledgeCheck.position.y - _wallCheck.position.y + 0.015f, _playerData.groundLayer);
        float yDistance = yHit.distance;
        workspace.Set(_wallCheck.position.x + xDistance * FacingDirection, _ledgeCheck.position.y - yDistance);
        return workspace;
    }

    public void SetThrowFalse()
    {
        _canThrow = false;
    }
    
    
    #endregion

}
