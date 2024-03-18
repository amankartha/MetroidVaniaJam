using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class SceneTeleportTrigger : MonoBehaviour
{
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private MMF_Player _mmfPlayer;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == GameManager.Instance.goMainPlayer)
        {
            _mmfPlayer.PlayFeedbacks();
        }
    }

    public void TelportPlayer()
    {
        GameManager.Instance.tMainPlayer.position = pos2.position;
    }
    
}
