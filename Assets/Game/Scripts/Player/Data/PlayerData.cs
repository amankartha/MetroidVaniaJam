using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newPlayerData",menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")] 
    public float movementVelocity = 10f;

    [Header("Jump State")] 
    public float jumpVelocity = 15f;
    public float secondJumpVelocity = 15f;
    public int numberOfJumps = 2;
    [Header("In Air")]
    public float aerialVelocity = 5f;
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;
    [Header("Checks")] 
    public float groundCheckRadius = 0.3f;
    public float wallCheckDistance = 0.5f;
    public LayerMask groundLayer;
    [Header("Wall Slide State")] 
    public float wallSlideVelocity = 3f;

    [Header("Wall Jump State")] 
    public float wallJumpVelocity = 20;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);
    [Header("Ledge Climb State")] 
    public Vector2 startOffset;
    public Vector2 stopOffset;
    [Header("Dodge State")] 
    public float dodgeDuration = 1f;
    public float dodgeVelocityX = 15f;
    
    [Header("Briefcase")]
    public float throwVelocity = 30f;
    public float throwMaxDuration = 0.5f;
    public float throwIdleDuration = 1f;
    public float teleportDelay = 0.3f;
    public LayerMask briefcaseReturnLayer;

    [Header("Health")]
    public int PlayerBaseHealth = 3;
    public int HealthPickupRange = 1;
    public int HPPotionRecoverAmount = 1;
    public int HPRecoverAmountRat = 1;
    public int HPRecoverAmountSheilder = 1;
    public int HPRecoverAmountCoffee = 1;
    public int HPRecoverAmountPenBoss = 1;
    public int PlayerBaseHPSection = 5;

    [Header("Upgrades")] 
    public int HealthIncreaseAmount = 1;

}
