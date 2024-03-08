using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoomTrigger : MonoBehaviour
{
    public PlayerMapLocation.MapArea mapArea;
    public int roomID;
    PlayerMapLocation playerMapLocation;

    private void Start()
    {
        playerMapLocation = GameManager.Instance.goMainPlayer.GetComponent<PlayerMapLocation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameManager.Instance.goMainPlayer)
        {
            playerMapLocation.UpdateCurrentLocation(mapArea, roomID);
        }
    }
}
