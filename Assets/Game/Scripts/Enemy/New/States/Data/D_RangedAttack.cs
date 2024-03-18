using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangedAttackState",menuName = "Data/State Data/Ranged Attack State" )]
public class D_RangedAttack : ScriptableObject
{
    public GameObject Projectile;
    public int Damage = 10;
    public float duration = 3f;
    public float cooldown = 2f;
    public float projectileTravelDistance;
}
