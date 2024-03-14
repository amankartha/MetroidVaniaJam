using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MessageCanvasUI : MonoBehaviour
{
    [SerializeField] RectTransform areaNameDisplayHolderRect;
    [SerializeField] TMP_Text areaNameText;
    public Vector2 targeAreaNameDisplayHolderPosition;
    Vector2 originalAreaNameDisplayHolderPosition;

    void Start()
    {
        areaNameDisplayHolderRect.gameObject.SetActive(false);
        originalAreaNameDisplayHolderPosition = areaNameDisplayHolderRect.anchoredPosition;
    }

    private void Update()
    {
        //testing animation
        /*if(Input.GetKeyDown(KeyCode.E))
        {
            ShowAreaName();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HideAreaName();
        }*/
    }

    public void ShowAreaName()
    {
        Sequence sequence = DOTween.Sequence();
        areaNameDisplayHolderRect.gameObject.SetActive(true);
        sequence.Append(areaNameDisplayHolderRect.DOAnchorPos(targeAreaNameDisplayHolderPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.1f));
        sequence.AppendInterval(1.5f);
        sequence.AppendCallback(() => HideAreaName());
    }

    public void HideAreaName()
    {
        areaNameDisplayHolderRect.DOAnchorPos(originalAreaNameDisplayHolderPosition, 0.3f).SetEase(Ease.OutQuad)
                        .OnComplete(() => DeactivateAreaNameDisplayHolder());
    }

    void DeactivateAreaNameDisplayHolder()
    {
        areaNameDisplayHolderRect.gameObject.SetActive(false);
    }

    public void SetAreaNameText(string area)
    {
        areaNameText.text = area;
    }
}
