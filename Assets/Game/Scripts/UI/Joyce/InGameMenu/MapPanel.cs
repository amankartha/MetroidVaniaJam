using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.InputSystem;

public class MapPanel : MonoBehaviour
{
    [SerializeField] RectTransform mapRightPageRect;
    [SerializeField] RectTransform mapHolderRect;
    [SerializeField] GameObject zoomTextHolder;
    [SerializeField] TMP_Text zoomText;

    public Quaternion targetMapRightRotation;
    Quaternion originalMapRightRotation;

    public Quaternion targetMapHolderRotation;
    Quaternion originalMapHolderRotation;

    public Vector2 targetMapHolderPosition;
    Vector2 originalMapHolderPosition;

    bool isFolded = true;

    [SerializeField] Sprite roomMapLeftSprite;
    [SerializeField] Sprite roomMapRightSprite;
    [SerializeField] Sprite worldMapLeftSprite;
    [SerializeField] Sprite worldMapRightSprite;
    [SerializeField] Image mapLeftImage;
    [SerializeField] Image mapRightImage;

    bool isZoomedIn;

    private void Start()
    {
        originalMapRightRotation = mapRightPageRect.rotation;
        originalMapHolderRotation = mapHolderRect.rotation;
        originalMapHolderPosition = mapHolderRect.anchoredPosition;
        mapLeftImage.sprite = worldMapLeftSprite;
        mapRightImage.sprite = worldMapRightSprite;
        zoomText.text = "Zoom In";
    }

    void OnEnable()
    {
        UnfoldMap();
    }

    private void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame && !isFolded)
        {
            ToggleMapZoom();
        }
    }

    public void UnfoldMap()
    {
        if (isFolded)
        {
            isFolded = false;
            mapRightPageRect.DORotateQuaternion(targetMapRightRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
            mapHolderRect.DORotateQuaternion(targetMapHolderRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f)
                .OnComplete(() => zoomTextHolder.SetActive(true));
        }       
    }

    public void FoldMap()
    {
        if (!isFolded)
        {
            isFolded = true;
            mapRightPageRect.DORotateQuaternion(originalMapRightRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
            mapHolderRect.DORotateQuaternion(originalMapHolderRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
            zoomTextHolder.SetActive(false);
        }        
    }

    public void MoveToTargetPosition()
    {
        mapHolderRect.DOAnchorPos(targetMapHolderPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
    }

    public void MoveToOriginalPosition()
    {
        mapHolderRect.DOAnchorPos(originalMapHolderPosition, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
    }

    public void ToggleMapZoom()
    {
        if (isZoomedIn)
        {
            mapLeftImage.sprite = worldMapLeftSprite;
            mapRightImage.sprite = worldMapRightSprite;
            zoomText.text = "Zoom In";
        }
        else
        {
            mapLeftImage.sprite = roomMapLeftSprite;
            mapRightImage.sprite = roomMapRightSprite;
            zoomText.text = "Zoom Out";
        }

        isZoomedIn = !isZoomedIn;
    }
}
