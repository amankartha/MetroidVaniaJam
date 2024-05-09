using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Transform RespawnLocation;

    public GameObject OpenEyes;
    public GameObject ClosedEyes;
    public GameObject interactUI;

    [SerializeField] private bool isOpen;

    private void Start()
    {
        GameManager.Instance.OnUpdatedRespawnPoint.AddListener(CloseEyes);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnUpdatedRespawnPoint.RemoveListener(CloseEyes);
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isOpen && col.gameObject == GameManager.Instance.goMainPlayer)
        {           
            isOpen = true;           
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isOpen && other.gameObject == GameManager.Instance.goMainPlayer)
        {
            if(GameManager.Instance.PlayerInputHandler.InteractInput)
            {
                GameManager.Instance.PlayerInputHandler.UseInteractInput();
                GameManager.Instance.OnUpdatedRespawnPoint?.Invoke();
                GameManager.Instance.CurrentRespawnPoint = this;
                GameManager.Instance.RespawnAllEnemies();
                ClosedEyes.SetActive(false);
                OpenEyes.SetActive(true);
                interactUI.SetActive(false);
            }
        }
    }

    private void CloseEyes()
    {
        ClosedEyes.SetActive(true);
        OpenEyes.SetActive(false);
        isOpen = false;
    }
}
