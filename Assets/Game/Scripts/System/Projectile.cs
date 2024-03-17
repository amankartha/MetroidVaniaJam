using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _duration;
    public Rigidbody2D rb;
    public BoxCollider2D _boxCollider2D;
    public SpriteRenderer _spriteRenderer;
    private int _damage;
    private float ArcPower = 5f;
    public ParticleSystem PS;
    protected virtual void Start()
    {
        rb.gravityScale = 0;

    }

    public virtual void SetValues(float duration, int damage)
    {
        _duration = duration;
        _damage = damage;
    }
    public virtual void ShootProjectile(Vector3 position)
    {
        rb.DOJump(position, ArcPower, 1, _duration).OnComplete(() => { rb.gravityScale = 7f;});
    }
    

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
        Explode();
        
    }
    

    public virtual void Explode()
    {
        _spriteRenderer.enabled = false;
        _boxCollider2D.enabled = false;
        PS.Play();
        Destroy(this.gameObject,5f);
    }
}
