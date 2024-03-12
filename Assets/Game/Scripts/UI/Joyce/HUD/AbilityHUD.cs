using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHUD : MonoBehaviour
{
    [SerializeField] Image abilityOneFillOmage;
    [SerializeField] Image abilityTwoFillOmage;

    public void UpdateAbilityOneCD()
    {
        float throwCooldown = GameManager.Instance.PlayerScript.ThrowCooldown;
        float throwCoolDownTimer = GameManager.Instance.PlayerScript.ThrowCooldownTimer;
        if (throwCoolDownTimer >= throwCooldown)
        {
            abilityOneFillOmage.fillAmount = 1f;
        }
        else if (throwCoolDownTimer <= 0)
        {
            abilityOneFillOmage.fillAmount = 0f;
        }
        else
        {
            abilityOneFillOmage.fillAmount = 1 - (float)throwCoolDownTimer / throwCooldown;
        }
    }

    public void UpdateAbilityTwoCD()
    {
        
    }
}
