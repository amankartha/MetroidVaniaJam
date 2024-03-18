using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Map : MonoBehaviour
{
    [SerializeField] RectTransform playerIconRect;
    [SerializeField] Transform mapOverlay;
    List<RoomPin> roomPins = new List<RoomPin>();

    public PlayerMapLocation playerMapLocation;
    public Dictionary<(PlayerMapLocation.MapArea, int), RoomPin> roomPinDic = new Dictionary<(PlayerMapLocation.MapArea, int), RoomPin>();

    RoomPin currentRoomPin;

    [Header("WorldMap")]
    public List<AreaMapImage> areaMapLeftImages = new List<AreaMapImage>();
    public List<AreaMapImage> areaMapRightImages = new List<AreaMapImage>();

    [Header("RegionalMap")]
    [SerializeField] Image regionalMapLeftImage;
    [SerializeField] Image regionalMapRightImage;
    public List<Sprite> regionalMapLeftSprites = new List<Sprite>();
    public List<Sprite> regionalMapRightSprites = new List<Sprite>();

    Dictionary<PlayerMapLocation.MapArea, Sprite> regionalMapLeftDic = new Dictionary<PlayerMapLocation.MapArea, Sprite>();
    Dictionary<PlayerMapLocation.MapArea, Sprite> regionalMapRightDic = new Dictionary<PlayerMapLocation.MapArea, Sprite>();

    List<RoomPin> holdOnToDisplayDiscovered = new List<RoomPin>();

    public InGameMenuUI inGameMenuUI;

    void Start()
    {
        playerMapLocation = GameManager.Instance.goMainPlayer.GetComponent<PlayerMapLocation>();

        RoomPin[] pins = mapOverlay.GetComponentsInChildren<RoomPin>();
        for (int i = 0; i < pins.Length; i++)
        {
            roomPins.Add(pins[i]);
            roomPinDic[(roomPins[i].mapArea, roomPins[i].roomID)] = roomPins[i];
        }

        for(int i = 0; i < regionalMapLeftSprites.Count; i++)
        {
            PlayerMapLocation.MapArea mapArea = (PlayerMapLocation.MapArea)i;
            regionalMapLeftDic.Add(mapArea, regionalMapLeftSprites[i]);
            regionalMapRightDic.Add(mapArea, regionalMapRightSprites[i]);

        }
    }

    public void UpdatePlayerRoomLocation(bool isRegionalMap)
    {
        if (playerMapLocation == null)
        {
            playerMapLocation = GameManager.Instance.goMainPlayer.GetComponent<PlayerMapLocation>();
        }
        var currentMapArea = playerMapLocation.GetCurrentMapArea();
        int currentRoomID = playerMapLocation.GetCurrentRoomID();
        RoomPin roomPin;

        //display room map location
        if (isRegionalMap)
        {
            if (roomPinDic.TryGetValue((currentMapArea, currentRoomID), out roomPin))
            {
                playerIconRect.anchoredPosition = roomPin.GetComponent<RectTransform>().anchoredPosition;
            }
        }
        //display world map location
        else
        {
            if (roomPinDic.TryGetValue((currentMapArea, -1), out roomPin))
            {
                playerIconRect.anchoredPosition = roomPin.GetComponent<RectTransform>().anchoredPosition;
                currentRoomPin = roomPin;
            }
        }

    }

    public void RevealNewAreaOnMap()
    {
        UpdatePlayerRoomLocation(false);

        if (currentRoomPin != null)
        {
            Debug.Log("revealed new area");

            foreach (AreaMapImage areaMapImage in areaMapLeftImages)
            {
                if (areaMapImage.mapArea == currentRoomPin.mapArea)
                {
                    areaMapImage.gameObject.SetActive(true);
                    break;
                }
            }

            foreach (AreaMapImage areaMapImage in areaMapRightImages)
            {
                if (areaMapImage.mapArea == currentRoomPin.mapArea)
                {
                    areaMapImage.gameObject.SetActive(true);
                    break;
                }
            }

            playerMapLocation.ObtainNewMap();

            for (int i = holdOnToDisplayDiscovered.Count - 1; i >= 0; i--)
            {
                RoomPin roomPin = holdOnToDisplayDiscovered[i];
                if (roomPin.mapArea == playerMapLocation.currentMapArea)
                {
                    roomPin.discoveredImage.enabled = true;
                    if (roomPin.savePoint != null)
                    {
                        roomPin.savePoint.SetActive(true);
                    }
                    holdOnToDisplayDiscovered.RemoveAt(i);
                }
            }

        }

        inGameMenuUI.OpenInGameMenu();
       
    }

    public void ShowRegionalMap()
    {
        if (playerMapLocation.ObtainedWorldMap.Contains(playerMapLocation.currentMapArea))
        {
            regionalMapLeftImage.gameObject.SetActive(true);
            regionalMapRightImage.gameObject.SetActive(true);
            mapOverlay.gameObject.SetActive(true);

            Sprite sprite;
            if (regionalMapLeftDic.TryGetValue(playerMapLocation.currentMapArea, out sprite))
            {
                regionalMapLeftImage.sprite = sprite;
            }
            if (regionalMapRightDic.TryGetValue(playerMapLocation.currentMapArea, out sprite))
            {
                regionalMapRightImage.sprite = sprite;
            }

            //toggle discovered images on regional maps
            for (int i = 0; i < roomPins.Count; i++)
            {
                RoomPin currentRoomPin = roomPins[i];

                if (currentRoomPin.discoveredImage != null)
                {
                    bool shouldEnable = currentRoomPin.mapArea == playerMapLocation.currentMapArea
                                        && currentRoomPin.isDiscovered;

                    currentRoomPin.discoveredImage.enabled = shouldEnable;
                }

                if (currentRoomPin.savePoint != null)
                {
                    bool shouldEnable = currentRoomPin.mapArea == playerMapLocation.currentMapArea
                                        && currentRoomPin.isDiscovered;

                    currentRoomPin.savePoint.SetActive(shouldEnable);
                }
            }
        }
    }

    public void HideRegionalMap()
    {
        regionalMapLeftImage.gameObject.SetActive(false);
        regionalMapRightImage.gameObject.SetActive(false);
        mapOverlay.gameObject.SetActive(false);
    }

    //event function
    public void UpdateNewRoom()
    {
        var currentMapArea = playerMapLocation.GetCurrentMapArea();
        int currentRoomID = playerMapLocation.GetCurrentRoomID();
        RoomPin roomPin;

        if (roomPinDic.TryGetValue((currentMapArea, currentRoomID), out roomPin))
        {
            roomPin.isDiscovered = true;
            if (playerMapLocation.ObtainedWorldMap.Contains(currentMapArea))
            {
                roomPin.discoveredImage.enabled = true;
                if (roomPin.savePoint != null)
                {
                    roomPin.savePoint.SetActive(true);
                }
            }
            else
            {
                holdOnToDisplayDiscovered.Add(roomPin);
            }
        }
    }
}
