using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLookingForPlayerState",menuName = "Data/State Data/LookingForPlayer State" )]
public class D_LookingForPlayer : ScriptableObject
{
   public int AmountOfTurns = 2;
   public float timeBetweenTurns = 0.75f;
}
