using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SawBlade : Interactable
{
    public ParticleSystem ParticleSystemGO;
    public Transform PSTransform;
    public GameObject SawBladeGameObject;
    public GameObject SawBladeGameObjectCollider;
    public Transform pos1;
    public Transform pos2;
    public float moveDuration = 1f;
    public float delay = 0.5f;
   
    protected override void Start()
    {
        base.Start();
        
        GoToPostwo();

    }

    public void GoToPosOne()
    {
        Sequence sequence1 = DOTween.Sequence();
        sequence1.AppendCallback(() => { PSTransform.transform.rotation = Quaternion.Euler(0,0,0); });
        sequence1.AppendCallback(() => { ParticleSystemGO.Play(); });
        sequence1.Append(
            SawBladeGameObject.transform
                .DOLocalRotate(new Vector3(0, 0, -10000), moveDuration, RotateMode.FastBeyond360).SetRelative(true)
                .SetEase(Ease.Linear));
        sequence1.Join(
             SawBladeGameObjectCollider.transform.DOMove(pos1.position, moveDuration).SetEase(Ease.Linear));
        
        sequence1.AppendCallback(() => { ParticleSystemGO.Stop(); });
        sequence1.AppendInterval(delay);
        sequence1.AppendCallback(() => GoToPostwo());
    }

    public void GoToPostwo()
    {
        Sequence sequence2 = DOTween.Sequence();
        sequence2.AppendCallback(() => { PSTransform.transform.rotation = Quaternion.Euler(0,180,0); });
        sequence2.AppendCallback(() => { ParticleSystemGO.Play(); });
        sequence2.Append(
        SawBladeGameObject.transform
            .DOLocalRotate(new Vector3(0, 0, 10000), moveDuration, RotateMode.FastBeyond360).SetRelative(true)
            .SetEase(Ease.Linear));
        sequence2.Join(
            SawBladeGameObjectCollider.transform.DOMove(pos2.position, moveDuration).SetEase(Ease.Linear));
        sequence2.AppendCallback(() => { ParticleSystemGO.Stop(); });
        sequence2.AppendInterval(delay);
        sequence2.AppendCallback(() => GoToPosOne());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == GameManager.Instance.goMainPlayer)
        {
            GameManager.Instance.PlayerHealthScript.TakeDamage(GameManager.Instance._interactablesData.SawDamage);
        }
    }
}

