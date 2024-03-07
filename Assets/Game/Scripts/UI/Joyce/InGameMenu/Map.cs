using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    void Start()
    {
        playerMapLocation = GameManager.Instance.goMainPlayer.GetComponent<PlayerMapLocation>();

        RoomPin[] pins = mapOverlay.GetComponentsInChildren<RoomPin>();
        for (int i = 0; i < pins.Length; i++)
        {
            roomPins.Add(pins[i]);
            roomPinDic[(roomPins[i].mapArea, roomPins[i].roomID)] = roomPins[i];
        }
    }

    public void UpdatePlayerRoomLocation(bool isRoomMap)
    {
        if (playerMapLocation == null)
        {
            playerMapLocation = GameManager.Instance.goMainPlayer.GetComponent<PlayerMapLocation>();
        }
        var currentMapArea = playerMapLocation.GetCurrentMapArea();
        var currentRoomID = playerMapLocation.GetCurrentRoomID();
        RoomPin roomPin;

        //display room map location
        if (isRoomMap)
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
                if(areaMapImage.mapArea == currentRoomPin.mapArea)
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

        }
    }

}
