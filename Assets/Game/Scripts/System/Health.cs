using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   
    public int HealthValue { get; set; } = 3;
    private int MaxHealth { get; set; }
    public int GoldenContractFragment { get; set; } = 0;


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

    public void CollcetGoldenContract()
    {
        GoldenContractFragment++;
        if(GoldenContractFragment >= 3)
        {
            MaxHealth++;
            GoldenContractFragment = 0;
        }
    }

    public void UpgradeHealth()
    {
        MaxHealth ++;
    }
}
