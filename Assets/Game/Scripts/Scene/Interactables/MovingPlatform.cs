using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovingPlatform : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    public Transform pos1;
    public Transform pos2;
    public float duration = 2f;
    private void Start()
    {
        _boxCollider2D = GetComponentInChildren<BoxCollider2D>();
        MoveToPos1();
    }


    public void MoveToPos1()
    {
       _boxCollider2D.transform.DOMove(pos1.position, duration).OnComplete(() => MoveToPos2());
    }

    public void MoveToPos2()
    {
        _boxCollider2D.transform.DOMove(pos2.position, duration).OnComplete(() => MoveToPos1());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == GameManager.Instance.goMainPlayer)
        {
            col.transform.parent = _boxCollider2D.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == GameManager.Instance.goMainPlayer)
        {
            other.transform.parent = null;
            SceneManager.MoveGameObjectToScene(other.gameObject,SceneManager.GetSceneByBuildIndex(1));
        }
    }
}
