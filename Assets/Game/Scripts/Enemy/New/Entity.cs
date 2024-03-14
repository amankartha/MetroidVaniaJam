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
    
    private EnemyHealth _enemyHealth;

    private float currentStunResistance;
    private float lastDamageTime;
    protected bool isStunned;
    
    
    #endregion

    #region MMFSTUFF

    public MMF_Player DamageMMF;
    

    #endregion
    
    #region Checks
    [SerializeField] 
    private Transform WallCheck;

    [SerializeField] 
    private Transform LedgeCheck;

    [SerializeField] 
    private Transform PlayerCheck;

    [SerializeField] 
    private Transform GroundCheck;
    #endregion
    
    
    public virtual void Start()
    {
        FacingDirection = 1;
        RB = AliveGo.GetComponent<Rigidbody2D>();
        Anim = AliveGo.GetComponent<Animator>();
        _enemyHealth = AliveGo.GetComponent<EnemyHealth>();
        _finiteStateMachine = new FiniteStateMachine();

        currentStunResistance = EntityData.stunResistance;
        _enemyHealth.OnEnemyDamaged.AddListener(Damaged);
        
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
        DamageMMF.PlayFeedbacks();
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
    
    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(WallCheck.position, AliveGo.transform.right, EntityData.WallCheckDistance,
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

    public virtual bool CheckPlayerInMinAggroRange()
    {
        return Physics2D.CircleCast( PlayerCheck.position, 1f,AliveGo.transform.right,EntityData.MinAggroDistance , EntityData.PlayerLayer);
    }

    public virtual bool CheckPlayerInMaxAggroRange()
    {
        return Physics2D.CircleCast(PlayerCheck.position,1f, AliveGo.transform.right,EntityData.MaxAggroDistance, EntityData.PlayerLayer);
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
