using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newStunStateData",menuName = "Data/State Data/Stun State" )]
public class D_StunState : ScriptableObject
{
    public float stunTime = 3f;
    public float stunKnockBackSpeed = 20f;
    public LayerMask playerLayer;
    public Vector2 stunKnockBackAngle;
}
