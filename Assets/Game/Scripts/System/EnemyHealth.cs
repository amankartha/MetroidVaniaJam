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
        _entity?.Respawn();
    }

    public override void Damage(int value)
    {
        
        HealthValue -= value;
        if (HealthValue <= 0)
        {
           _entity.ENEMYCHECK.DESPAWN();
        }
        else
        {
            OnEnemyDamaged.Invoke();
        }
    }
    
    
}
