using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Laser : Interactable
{
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public float length = 10f;
    public float beamDelay = 2f;
    public float smallBeamDuration = 0.3f;
    public float smallBeamWidth = 0.1f;
    public float bigBeamWidth = 0.40f;
    
    public GameObject startVFX;
    public GameObject startBeam;

    public GameObject lightGO;
    
    protected override void Start()
    {
        base.Start();
        DisableLaser();
        lineRenderer.SetPosition(1,new Vector3(length,0));
        LoopingBeam();
    }

    public void EnableLineRenderer()
    {
        lineRenderer.enabled = true;
    }

    public void DisableLaser()
    {
        lineRenderer.enabled = false;
    }

    public void LoopingBeam()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.SetLoops(-1);
        sequence.AppendInterval(beamDelay);
        sequence.AppendCallback(() => { startBeam.SetActive(true); });
        sequence.AppendInterval(beamDelay);
        sequence.AppendCallback(() => { startVFX.SetActive(true); });
        sequence.AppendInterval(beamDelay);
        sequence.AppendCallback(() => { startVFX.SetActive(false); });
        sequence.AppendCallback(() => { lightGO.SetActive(true); });
        sequence.AppendCallback(() => { startBeam.GetComponent<ParticleSystem>().Stop(); });
        sequence.AppendCallback(() => { lineRenderer.enabled = true; });
        sequence.AppendCallback(() => { lineRenderer.widthMultiplier = smallBeamWidth;});
        sequence.AppendInterval(smallBeamDuration);
        sequence.AppendCallback(() => { lineRenderer.widthMultiplier = bigBeamWidth;});
        sequence.AppendInterval(beamDelay);
        sequence.AppendCallback(() => { lineRenderer.widthMultiplier = smallBeamWidth;});
        sequence.AppendInterval(smallBeamDuration);
        sequence.AppendCallback(() => { lineRenderer.enabled = false; });
        sequence.AppendCallback(() => { startBeam.SetActive(false); });
        sequence.AppendCallback(() => { lightGO.SetActive(false); });
        
    }
    
}
