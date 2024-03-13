using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class DestructableWallHealth : Health
{
    public MMF_Player _mmfPlayer;
    public override void Damage(int value)
    {
        HealthValue -= value;
        _mmfPlayer.PlayFeedbacks();
        if (HealthValue <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
