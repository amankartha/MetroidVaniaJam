using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenProjectile : Projectile
{
    private EliteEnemy _enemy;
    
    void Start()
    {
        
    }

    public void SetValuesForPen(float duration, int damage,EliteEnemy enemy)
    {
        base.SetValues(duration, damage);
        _enemy = enemy;
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }

        if (col.gameObject.layer == 3)
        {
            Impact(col.GetContact(0).point);
        }
    }

    public  void Impact(Vector3 pos)
    {
        _enemy.TeleportState.SetTeleportPos(pos);
    }
}
