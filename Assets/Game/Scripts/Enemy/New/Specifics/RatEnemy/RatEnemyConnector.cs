using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemyConnector : MonoBehaviour
{
    [SerializeField] private int damageOnhit;
    [SerializeField] private float knockBackPower = 10f;
    [SerializeField] private Vector2 angle = new Vector2(0, 1);
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == GameManager.Instance.goMainPlayer)
        {
            GameManager.Instance.PlayerHealthScript.DamageWithKnockBack(damageOnhit,knockBackPower,angle,1);
        }
    }
}
