using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    [SerializeField] private Entity _entity;

    public UnityEvent OnEnemyDamaged;

    private void OnEnable()
    {
        HealthValue = MaxHealth;
    }

    public override void Damage(int value)
    {
        OnEnemyDamaged.Invoke();
        HealthValue -= value;
        if (HealthValue <= 0)
        {
           _entity.ENEMYCHECK.DESPAWN();
        }
    }
    
    
}
