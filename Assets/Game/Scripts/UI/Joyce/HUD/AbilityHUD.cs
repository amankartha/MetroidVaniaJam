using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHUD : MonoBehaviour
{
    [SerializeField] Image abilityOneFillImage;
    [SerializeField] Image abilityTwoFillImage;
    public Image throwImage;
    public Sprite throwIcon, teleportIcon;
    bool isBriefOnHand = true;

    public void UpdateAbilityOneCD()
    {
        float throwCooldown = GameManager.Instance.PlayerScript.ThrowCooldown;
        float throwCoolDownTimer = GameManager.Instance.PlayerScript.ThrowCooldownTimer;
        if (throwCoolDownTimer >= throwCooldown)
        {
            abilityOneFillImage.fillAmount = 0f;
        }
        /*else if (throwCoolDownTimer <= 0)
        {
            abilityOneFillOmage.fillAmount = 1f;
        }*/
        else
        {
            abilityOneFillImage.fillAmount = (float)throwCoolDownTimer / throwCooldown;
        }

    }

    public void SwapThrowAbilityIcon()
    {
        if (isBriefOnHand)
        {
            throwImage.sprite = throwIcon;
        }
        else
        {
            throwImage.sprite = teleportIcon;
        }
        isBriefOnHand = !isBriefOnHand;
    }

}
