using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLink : MonoBehaviour
{
    public ShieldEnemy Enemy;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject == GameManager.Instance.goMainPlayer && Enemy._finiteStateMachine.CurrentState == Enemy.ChargeState)
        {
           Enemy.TransitionToStunned();
        }
    }

}
