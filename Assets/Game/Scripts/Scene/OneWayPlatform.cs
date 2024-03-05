using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class OneWayPlatform : MonoBehaviour
{
    private BoxCollider2D _boxCollider2d;
    private Collider2D _playerCollider;
    private void Start()
    {
        _boxCollider2d = GetComponent<BoxCollider2D>();
    }
   
    private void OnCollisionStay2D(Collision2D collision)
    {
       
        if (GameManager.Instance.PlayerScript.InputHandler.NormInputY < 0)
        {
            
            if (collision.collider.gameObject.layer == 7)
            {
                _playerCollider = collision.collider;
                Physics2D.IgnoreCollision(this._boxCollider2d,collision.collider,true);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if(_playerCollider != null) Physics2D.IgnoreCollision(this._boxCollider2d, _playerCollider, false);
    }

   
}
