using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   
    public int HealthValue { get; set; } = 3;
    public int MaxHealth { get; set; }
    public int HPSection { get; set; }
    public int HealthPerSection { get; set; }
    public int GoldenContractFragment { get; set; } = 0;


    void Start()
    {
        MaxHealth = HealthValue;
        HealthPerSection = MaxHealth / HPSection;
    }


    void Update()
    {
        
    }


    public void ModifyHealth(int value)
    {
        HealthValue += value;
    }

    public bool CollcetGoldenContract()
    {
        GoldenContractFragment++;
        if(GoldenContractFragment >= 3)
        {
            HPSection++;
            MaxHealth += HealthPerSection;
            HealthValue = MaxHealth;
            GoldenContractFragment = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

}
