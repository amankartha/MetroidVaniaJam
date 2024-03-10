using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Transform RespawnLocation;

    public GameObject OpenEyes;
    public GameObject ClosedEyes;


    [SerializeField] private bool isOpen;

    private void Start()
    {
        GameManager.Instance.OnUpdatedRespawnPoint.AddListener(CloseEyes);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnUpdatedRespawnPoint.RemoveListener(CloseEyes);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isOpen && col.gameObject == GameManager.Instance.goMainPlayer)
        {
            GameManager.Instance.OnUpdatedRespawnPoint?.Invoke();
            GameManager.Instance.CurrentRespawnPoint = this;
            isOpen = true;
            ClosedEyes.SetActive(false);
            OpenEyes.SetActive(true);
        }
    }

    private void CloseEyes()
    {
        ClosedEyes.SetActive(true);
        OpenEyes.SetActive(false);
        isOpen = false;
    }
}
