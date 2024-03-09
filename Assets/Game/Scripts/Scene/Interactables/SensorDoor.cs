using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SensorDoor : MonoBehaviour
{
    public SpriteRenderer DoorEye;
    public GameObject Door;
    public Transform ClosePosition;
    public Transform OpenPosition;
    public float moveDuration = 1f;
    
    public Light2D Light2D;




    public void CloseDoor()
    {
        Door.transform.DOMove(ClosePosition.position, moveDuration);
        DoorEye.color = Color.red;
    }
    
    public void OpenDoor()
    {
       Door.transform.DOMove(OpenPosition.position, moveDuration);
       DoorEye.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        CloseDoor();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OpenDoor();
    }
}
