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
        Tweener t =transform.DOMove(_initTransform.position, _playerData.throwMaxDuration);
         t.OnUpdate(() => ReturnHelper(t));
         t.Play();
    }

    public void ThrowBriefcase()
    {
        _throwSequence = DOTween.Sequence();
        _throwSequence.OnComplete(ReturnToCharacter);
        _throwSequence.AppendCallback(() => _animator.SetBool("rotate", true));
        _throwSequence.AppendCallback(() => _isBriefcaseInHand = false);
        
        _throwSequence.Append(transform.DOMove(
            this.transform.position + new Vector3(_playerData.throwMaxDistance, 0, 0) * _player.FacingDirection
            , _playerData.throwMaxDuration));
        _throwSequence.AppendInterval(0.4f);
    }

    private void ReturnHelper(Tweener tweener)
    {
        tweener.ChangeEndValue(_initTransform.position);
        if (Vector2.Distance(this.transform.position, _initTransform.transform.position) < 0.2f)
        {
            tweener.Kill();
            _animator.SetBool("rotate", false);
            _isBriefcaseInHand = true;
        }
       
    }
}
