using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newSpinState",menuName = "Data/State Data/Spin State" )]
public class D_SpinState : ScriptableObject
{
   public float SpinDuration = 2f;
   public int SpinDamage = 10;
   public float SpinRadius = 2f;
}
