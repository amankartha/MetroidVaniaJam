using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using Unity.Mathematics;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Variables

    public EnemyCheck ENEMYCHECK;
    
    public FiniteStateMachine _finiteStateMachine;
    
    public D_Entity EntityData;
    public int FacingDirection { get; private set; }
    private Vector2 velocityWorkspace;
    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }
    [field:SerializeField]public GameObject AliveGo { get; private set; }
    public BoxCollider2D _boxCollider2D;
    public AnimationToStateMachine atsm { get; private set; }
    private EnemyHealth _enemyHealth;

    private float currentStunResistance;
    private float lastDamageTime;
    protected bool isStunned;
    
    
    #endregion

    #region MMFSTUFF

  
    

    #endregion
    
    #region Checks
    [SerializeField] 
    private Transform WallCheck;
    
    [SerializeField] 
    private Transform WallCheckBehind;

    [SerializeField] 
    private Transform LedgeCheck;
    
    [SerializeField] 
    private Transform LedgeCheckBehind;

    [SerializeField] 
    private Transform PlayerCheck;

    [SerializeField] 
    private Transform GroundCheck;
    #endregion
    
    
    public virtual void Start()
    {
        FacingDirection = 1;
        RB = AliveGo.GetComponent<Rigidbody2D>();
        Anim = AliveGo.GetComponentInChildren<Animator>();
        _enemyHealth = AliveGo.GetComponent<EnemyHealth>();
        _finiteStateMachine = new FiniteStateMachine();

        currentStunResistance = EntityData.stunResistance;
        _enemyHealth.OnEnemyDamaged.AddListener(Damaged);
        atsm = AliveGo.GetComponentInChildren<AnimationToStateMachine>();
        _boxCollider2D = AliveGo.GetComponent<BoxCollider2D>();

    }

    public virtual void Update()
    {
        _finiteStateMachine.CurrentState.LogicUpdate();

        if (Time.time >= lastDamageTime + EntityData.stunRecoveryTime)
        {
            ResetStunReistance();
        }
    }

    public virtual void FixedUpdate()
    {
        _finiteStateMachine.CurrentState.PhysicsUpdate();
    }

    public void OnDestroy()
    {
        _enemyHealth.OnEnemyDamaged.RemoveListener(Damaged);
    }

    public virtual void ResetStunReistance()
    {
        isStunned = false;
        currentStunResistance = EntityData.stunResistance;
    }
    public virtual void Damaged()
    {
       
        lastDamageTime = Time.time;
        currentStunResistance -= GameManager.Instance.PlayerScript._playerData.StunDamageAmount;
        if (currentStunResistance < 0)
        {
            isStunned = true;
        }
    }
    
    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(FacingDirection * velocity,RB.velocity.y);
        RB.velocity = velocityWorkspace;
    }

    public virtual void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        velocityWorkspace.Set(angle.x*velocity*direction,angle.y*velocity);
        RB.velocity = velocityWorkspace;
    }

    public virtual int GetDamageDirection()
    {
        if (GameManager.Instance.goMainPlayer.transform.position.x > AliveGo.transform.position.x)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    public virtual void Respawn()
    {
        
    }
    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(WallCheck.position, AliveGo.transform.right, EntityData.WallCheckDistance,
            EntityData.GroundLayer);
    }
    public virtual bool CheckWallBehind()
    {
        return Physics2D.Raycast(WallCheckBehind.position, -AliveGo.transform.right, EntityData.WallCheckDistance,
            EntityData.GroundLayer);
    }

    public virtual bool CheckGround()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, EntityData.GroundCheckRadius, EntityData.GroundLayer);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(LedgeCheck.position,Vector2.down,EntityData.LedgeCheckDistance,EntityData.GroundLayer);
    }
    public virtual bool CheckLedgeBehind()
    {
        return Physics2D.Raycast(LedgeCheckBehind.position,Vector2.down,EntityData.LedgeCheckDistance,EntityData.GroundLayer);
    }

    public virtual bool CheckPlayerInMinAggroRange()
    {
        return Physics2D.CircleCast( PlayerCheck.position, 1f,AliveGo.transform.right,EntityData.MinAggroDistance , EntityData.PlayerLayer);
    }

    public virtual bool CheckPlayerInMaxAggroRange()
    {
        return Physics2D.CircleCast(PlayerCheck.position,1f, AliveGo.transform.right,EntityData.MaxAggroDistance, EntityData.PlayerLayer);
    }
    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.CircleCast(PlayerCheck.position,3f, transform.right, EntityData.CloseRangeActionDistance, EntityData.PlayerLayer);
    }
    public virtual bool CheckPlayerInLongRangeAction()
    {
        return Physics2D.CircleCast(PlayerCheck.position,3f, transform.right, EntityData.LongRangeActionDistance, EntityData.PlayerLayer);
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
        Gizmos.DrawLine(PlayerCheck.position,PlayerCheck.position + (Vector3)(Vector2.right * FacingDirection * EntityData.CloseRangeActionDistance));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(PlayerCheck.position,PlayerCheck.position + (Vector3)(Vector2.right * FacingDirection * EntityData.LongRangeActionDistance));
    }
}
