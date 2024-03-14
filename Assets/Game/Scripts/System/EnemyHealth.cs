using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private Entity _entity;


    private void OnEnable()
    {
        HealthValue = MaxHealth;
    }

    public override void Damage(int value)
    {
        HealthValue -= value;
        if (HealthValue <= 0)
        {
           _entity.ENEMYCHECK.DESPAWN();
        }
    }
    
    
}
