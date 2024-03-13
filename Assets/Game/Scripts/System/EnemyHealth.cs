using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void Damage(int value)
    {
        HealthValue -= value;
        if (HealthValue <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    
    
}
