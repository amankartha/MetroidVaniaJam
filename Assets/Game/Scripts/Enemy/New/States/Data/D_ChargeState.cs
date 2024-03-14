using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newChargeState",menuName = "Data/State Data/Charge State" )]
public class D_ChargeState : ScriptableObject
{
   public float ChargeSpeed = 10f;
   public float ChargeTime = 2f;
}
