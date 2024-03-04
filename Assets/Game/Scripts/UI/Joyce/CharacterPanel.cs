using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] RectTransform discriptionPanelRect;
    public Vector2 targetPosition;
    Vector2 originalPosition;

    void Start()
    {
        originalPosition = discriptionPanelRect.anchoredPosition;
    }

    void OnEnable()
    {
        MoveToTargetPosition();
    }


    public void MoveToTargetPosition()
    {
        discriptionPanelRect.DOAnchorPos(targetPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
    }

    public void MoveToOriginalPosition()
    {
        discriptionPanelRect.DOAnchorPos(originalPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
    }
}
