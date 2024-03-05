using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemPanel : MonoBehaviour
{
    [SerializeField] RectTransform itemHolderRect;
    public Vector2 targetDisplayPosition;
    public Quaternion targetDisplayRotation;
    Vector2 originalPosition;
    private Quaternion originalRotation;
    public Vector2 targetMapPosition;

    [SerializeField] GameObject discriptionHolder;

    void Start()
    {
        originalPosition = itemHolderRect.anchoredPosition;
        originalRotation = itemHolderRect.rotation; 
    }

    //when item tab is pressed
    public void MoveToTargetDisplayPosition()
    {
        itemHolderRect.DOAnchorPos(targetDisplayPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
        itemHolderRect.DORotateQuaternion(targetDisplayRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f)
            .OnComplete(() => ActivateDiscriptionHolder());
    }

    public void MoveToOriginalPosition()
    {
        itemHolderRect.DOAnchorPos(originalPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
        itemHolderRect.DORotateQuaternion(originalRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
    }

    //move along with map
    public void MoveToMapPosition()
    {
        itemHolderRect.DOAnchorPos(targetMapPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
        itemHolderRect.DORotateQuaternion(originalRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f)
            .OnComplete(() => ActivateDiscriptionHolder());
    }

    void ActivateDiscriptionHolder()
    {
        discriptionHolder.SetActive(true);
    }
}
