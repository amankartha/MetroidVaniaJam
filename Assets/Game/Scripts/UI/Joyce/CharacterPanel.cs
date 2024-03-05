using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] RectTransform characterHolderRect;
    [SerializeField] GameObject discriptionHolder;

    public Vector2 targeCharacterHolderPosition;
    Vector2 originalCharacterHolderPosition;

    bool isMoved = false;

    void Start()
    {
        originalCharacterHolderPosition = characterHolderRect.anchoredPosition;
    }

    public void MoveToTargetPosition()
    {
        if (!isMoved)
        {
            characterHolderRect.DOAnchorPos(targeCharacterHolderPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f)
                .OnComplete(() => DeactivateDiscriptionHolder());
            isMoved = true;
        }
    }

    public void MoveToOriginalPosition()
    {
        if (isMoved)
        {
            characterHolderRect.DOAnchorPos(originalCharacterHolderPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
            isMoved = false;
        }
    }

    void DeactivateDiscriptionHolder()
    {
        discriptionHolder.SetActive(false);
    }
}
