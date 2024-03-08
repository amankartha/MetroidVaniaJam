using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedSurface : Interactable
{
    public Vector2 knockBackDirection = new Vector2(3f, 15f);
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == GameManager.Instance.goMainPlayer)
        {
            GameManager.Instance.PlayerScript.SetVelocity(GameManager.Instance._interactablesData.SpikesKnockBackPower, knockBackDirection,GameManager.Instance.PlayerScript.FacingDirection);
            GameManager.Instance.PlayerHealthScript.TakeDamage(GameManager.Instance._interactablesData.SpikesDamage);

           
        }
    }
}
