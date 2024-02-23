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
    public int numberOfJumps = 2;
    [Header("In Air")]
    public float aerialVelocity = 5f;
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;
    [Header("Checks")] 
    public float groundCheckRadius = 0.3f;

    

    public LayerMask groundLayer;
}
