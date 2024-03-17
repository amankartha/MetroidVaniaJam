using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    [SerializeField] private Entity _entity;
    public UnityEvent OnEnemyDamaged;
    public bool isShieldEnemy;
    private void OnEnable()
    {
        HealthValue = MaxHealth;
        _entity?.Respawn();
    }

    public override void Damage(int value)
    {
        if (isShieldEnemy)
        {
            Vector3 directionToEnemy = (this.transform.position - GameManager.Instance.tMainPlayer.position).normalized;
            Vector3 directionOfPlayer = GameManager.Instance.tMainPlayer.forward;

            float angle = Vector3.Angle(directionToEnemy, directionOfPlayer);

            if (angle <= 180f / 2)
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
        else
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
    
    
}
