using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MessageCanvasUI : MonoBehaviour
{
    [SerializeField] RectTransform areaNameDisplayHolderRect;
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
        areaNameDisplayHolderRect.gameObject.SetActive(true);
        areaNameDisplayHolderRect.DOAnchorPos(targeAreaNameDisplayHolderPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.1f);
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
}
