using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MapPanel : MonoBehaviour
{
    [SerializeField] RectTransform mapRightPageRect;
    [SerializeField] RectTransform mapHolderRect;

    public Quaternion targetMapRightRotation;
    Quaternion originalMapRightRotation;

    public Quaternion targetMapHolderRotation;
    Quaternion originalMapHolderRotation;

    public Vector2 targetMapHolderPosition;
    Vector2 originalMapHolderPosition;


    private void Start()
    {
        originalMapRightRotation = mapRightPageRect.rotation;
        originalMapHolderRotation = mapHolderRect.rotation;
        originalMapHolderPosition = mapHolderRect.anchoredPosition;
    }

    void OnEnable()
    {
        UnfoldMap();
    }

    public void UnfoldMap()
    {
        mapRightPageRect.DORotateQuaternion(targetMapRightRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
        mapHolderRect.DORotateQuaternion(targetMapHolderRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
    }

    public void FoldMap()
    {
        mapRightPageRect.DORotateQuaternion(originalMapRightRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
        mapHolderRect.DORotateQuaternion(originalMapHolderRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
    }

    public void MoveToTargetPosition()
    {
        mapHolderRect.DOAnchorPos(targetMapHolderPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
    }

    public void MoveToOriginalPosition()
    {
        mapHolderRect.DOAnchorPos(originalMapHolderPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
    }

}
