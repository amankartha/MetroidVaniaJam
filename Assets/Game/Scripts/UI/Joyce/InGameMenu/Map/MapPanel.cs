using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

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

    public bool isFolded = true;

    [SerializeField] Sprite roomMapLeftSprite;
    [SerializeField] Sprite roomMapRightSprite;
    [SerializeField] Sprite worldMapLeftSprite;
    [SerializeField] Sprite worldMapRightSprite;
    [SerializeField] Image mapLeftImage;
    [SerializeField] Image mapRightImage;
    [SerializeField] GameObject playerMapIcon;

    bool isZoomedIn;

    [SerializeField] Map map;

    private void Start()
    {
        originalMapRightRotation = mapRightPageRect.rotation;
        originalMapHolderRotation = mapHolderRect.rotation;
        originalMapHolderPosition = mapHolderRect.anchoredPosition;
        zoomText.text = "Zoom In";
        map.HideRegionalMap();
    }

    private void Update()
    {
        if (GameManager.Instance.PlayerInputHandler.MapZoomInput && !isFolded)
        {
            GameManager.Instance.PlayerInputHandler.UseMapZoomInput();
            ToggleMapZoom();
        }
    }

    public void UnfoldMap()
    {
        if (isFolded)
        {
            isFolded = false;
            UpdateMap(!isZoomedIn);
            map.UpdatePlayerRoomLocation(isZoomedIn);
            mapRightPageRect.DORotateQuaternion(targetMapRightRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
            mapHolderRect.DORotateQuaternion(targetMapHolderRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f)
                .OnComplete(() => ToggleIconsDisplay(true));
        }
    }

    public void FoldMap()
    {
        if (!isFolded)
        {
            isFolded = true;
            mapRightPageRect.DORotateQuaternion(originalMapRightRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
            mapHolderRect.DORotateQuaternion(originalMapHolderRotation, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.2f);
            ToggleIconsDisplay(false);
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
            UpdateMap(true);
            zoomText.text = "Zoom In";
        }
        else
        {
            UpdateMap(false);
            
            zoomText.text = "Zoom Out";
        }
        isZoomedIn = !isZoomedIn;
        map.UpdatePlayerRoomLocation(isZoomedIn);
    }

    void UpdateMap(bool isWorldMap)
    {
        List<AreaMapImage> areaMapLeftImages = map.areaMapLeftImages;
        List<AreaMapImage> areaMapRightImages = map.areaMapRightImages;

        //world map
        if (isWorldMap)
        {
            map.HideRegionalMap();
            foreach (AreaMapImage areaMapImage in areaMapLeftImages)
            {
                if (areaMapImage.gameObject.activeSelf)
                {
                    areaMapImage.gameObject.GetComponent<Image>().sprite = areaMapImage.worldMapSprite;
                }
            }
            foreach (AreaMapImage areaMapImage in areaMapRightImages)
            {
                if (areaMapImage.gameObject.activeSelf)
                {
                    areaMapImage.gameObject.GetComponent<Image>().sprite = areaMapImage.worldMapSprite;
                }
            }
        }
        //regional map
        else
        {           
            /*foreach (AreaMapImage areaMapImage in areaMapLeftImages)
            {
                if (areaMapImage.gameObject.activeSelf)
                {
                    //areaMapImage.gameObject.GetComponent<Image>().sprite = areaMapImage.regionalMapSprite;
                    areaMapImage.gameObject.SetActive(false);
                }
            }
            foreach (AreaMapImage areaMapImage in areaMapRightImages)
            {
                if (areaMapImage.gameObject.activeSelf)
                {
                    //areaMapImage.gameObject.GetComponent<Image>().sprite = areaMapImage.regionalMapSprite;
                    areaMapImage.gameObject.SetActive(false);
                }
            }*/
            map.ShowRegionalMap();
        }

    }

    void ToggleIconsDisplay(bool setToActive)
    {
        zoomTextHolder.SetActive(setToActive);
        playerMapIcon.SetActive(setToActive);
    }
}
