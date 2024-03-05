using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HealthValue { get; set; } = 3;
    private int MaxHealth { get; set; }
    

    void Start()
    {
        MaxHealth = HealthValue;
    }

    
    void Update()
    {
        
    }


    public void ModifyHealth(int value)
    {
        HealthValue += value;
    }
}
