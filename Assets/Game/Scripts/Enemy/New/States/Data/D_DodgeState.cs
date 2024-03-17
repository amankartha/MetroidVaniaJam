using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newDodgeStateData",menuName = "Data/State Data/Dodge State" )]
public class D_DodgeState : ScriptableObject
{
   public float DodgeSpeed = 10f;
   public Vector2 DodgeAngle ;
   public float DodgeTime = 0.2f;
   public float DodgeCooldown = 2f;
}
