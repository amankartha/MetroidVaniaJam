using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapLocation : MonoBehaviour
{
    MapArea currentMapArea;
    int currentRoomID;
    public bool unlockMap = false;

    public MapArea GetCurrentMapArea()
    {
        return currentMapArea;
    }

    public int GetCurrentRoomID()
    {
        return currentRoomID;
    }

    public void UpdateCurrentLocation(MapArea area, int id)
    {
        currentMapArea = area;
        currentRoomID = id;
    }
    

    public enum MapArea
    {
        Tunnel,
        Warehouse,
        Workspace,
        Lab
    }
}
