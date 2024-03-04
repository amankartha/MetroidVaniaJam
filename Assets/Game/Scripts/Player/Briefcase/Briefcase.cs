using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Briefcase : MonoBehaviour
{
    [SerializeField] private Player _player;
    private BoxCollider2D _boxCollider2D;
    [SerializeField] private PlayerData _playerData;
    private Sequence _throwSequence;
    private Animator _animator;
   
    public Transform _initTransform;
    public bool _isBriefcaseInHand;
    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
     
        _isBriefcaseInHand = true;
    }


   

    public void ReturnToCharacter()
    {
     
    }

    public void ThrowBriefcase()
    {
       
    }

    private void ReturnHelper(Tweener tweener)
    {
        
       
    }
}
