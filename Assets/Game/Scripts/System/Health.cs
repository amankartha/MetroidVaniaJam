using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
   
    [field:SerializeField]public int HealthValue { get; protected set; } = 3;
    [field:SerializeField]public int MaxHealth { get; set; }
    public int HPSection { get; set; } = 5;
    public int HealthPerSection { get; set; }
    public int GoldenContractFragment { get; set; } = 0;


    protected virtual void Start()
    {
        MaxHealth = HealthValue;
        HealthPerSection = MaxHealth / HPSection;
    }


    public virtual void SetHealth(int value)
    {
        HealthValue = value;
    }
    
    public virtual void Damage(int value)
    {
        HealthValue -= value;
    }

    public virtual void Heal(int value)
    {
        HealthValue += value;
        HealthValue = math.clamp(HealthValue, 0, MaxHealth);
    }

    public virtual void ModifyMaxHealth(int value, bool healWithMaxHealthIncrease = false)
    {
        MaxHealth += value;
        if (healWithMaxHealthIncrease)
        {
            Heal(value);
        }

    }

    public bool CollcetGoldenContract()
    {
        GoldenContractFragment++;
        if(GoldenContractFragment % 3 == 0)
        {
            HPSection++;
            MaxHealth += HealthPerSection;
            HealthValue = MaxHealth;
            //GoldenContractFragment = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TakeDamage(int value)
    {
        Debug.Log($"{this.gameObject.name} has taken {value} damage" );
        Damage(value);
    }
}
