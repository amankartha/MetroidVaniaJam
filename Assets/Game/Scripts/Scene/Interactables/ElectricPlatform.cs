using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ElectricPlatform : MonoBehaviour
{
    public float ElectrityOnDuration = 2f;
    public float ElectricityOffDuration = 2f;

    public BoxCollider2D triggerCollider;
    public BoxCollider2D Collider;

    public GameObject vfx;
    public GameObject Light;

    public Vector2 knockBackDirection = new Vector2(5, 5);
    
    // Start is called before the first frame update
    void Start()
    {
        Loop();
    }

    public void Loop()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.SetLoops(-1);
        sequence.AppendInterval(ElectricityOffDuration);
        sequence.AppendCallback(TurnOn);
        sequence.AppendInterval(ElectrityOnDuration);
        sequence.AppendCallback(TurnOff);
    }

    public void TurnOn()
    {
        triggerCollider.enabled = false;
        vfx.SetActive(false);
        Light.SetActive(false);
    }

    public void TurnOff()
    {
        triggerCollider.enabled = true;
        vfx.SetActive(true);
        Light.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == GameManager.Instance.goMainPlayer)
        {
            GameManager.Instance.PlayerScript.SetVelocity(GameManager.Instance._interactablesData.ElectricityKnockBackPower, knockBackDirection,GameManager.Instance.PlayerScript.FacingDirection);
            GameManager.Instance.PlayerHealthScript.TakeDamage(GameManager.Instance._interactablesData.ElectricityDamage);

           
        }
    }
}
