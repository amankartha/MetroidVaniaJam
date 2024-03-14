using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "newPlayerDetectedState",menuName = "Data/State Data/Detected State" )]
public class D_PlayerDetected : ScriptableObject
{
    [FormerlySerializedAs("ActionTime")] public float longRangeActionTime = 1.5f;
    
}
