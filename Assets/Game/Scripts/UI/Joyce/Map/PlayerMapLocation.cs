using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapLocation : MonoBehaviour
{
    public MapArea currentMapArea;
    public int currentRoomID;
    public List<MapArea> ObtainedWorldMap = new List<MapArea>();
    public MessageCanvasUI messageCanvasUI;

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
        if(area != currentMapArea)
        {
            messageCanvasUI.SetAreaNameText(area.ToString());
            messageCanvasUI.ShowAreaName();
        }
        currentMapArea = area;
        currentRoomID = id;
    }

    public void ObtainNewMap()
    {
        ObtainedWorldMap.Add(currentMapArea);
    }
    

    public enum MapArea
    {
        Tunnel,
        Warehouse,
        Workspace,
        Lab
    }
}
