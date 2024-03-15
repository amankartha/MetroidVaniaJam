using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] RectTransform characterHolderRect;
    [SerializeField] GameObject discriptionHolder;

    public Vector2 targeCharacterHolderPosition;
    Vector2 originalCharacterHolderPosition;

    bool isMoved = false;

    public TMP_Text potionInventoryText;
    public TMP_Text goldenContractFragText;

    void Start()
    {
        originalCharacterHolderPosition = characterHolderRect.anchoredPosition;
    }

    private void OnEnable()
    {
        UpdateInventoryText();
    }

    public void MoveToTargetPosition()
    {
        if (!isMoved)
        {
            characterHolderRect.DOAnchorPos(targeCharacterHolderPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f).SetUpdate(true)
                .OnComplete(() => DeactivateDiscriptionHolder());
            isMoved = true;
        }
    }

    public void MoveToOriginalPosition()
    {
        if (isMoved)
        {
            characterHolderRect.DOAnchorPos(originalCharacterHolderPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f).SetUpdate(true);
            isMoved = false;
        }
    }

    void DeactivateDiscriptionHolder()
    {
        discriptionHolder.SetActive(false);
    }

    void UpdateInventoryText()
    {
        int maxPotions = GameManager.Instance.PlayerScript.MaxPotions;
        int currentPotions = GameManager.Instance.PlayerScript.PotionCount;
        potionInventoryText.text = currentPotions + "/" + maxPotions;

        int goldenContractFrag = GameManager.Instance.PlayerHealthScript.GoldenContractFragment;
        goldenContractFragText.text = goldenContractFrag.ToString();
    }
}
