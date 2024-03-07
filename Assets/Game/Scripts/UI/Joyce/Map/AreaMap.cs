using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AreaMap : MonoBehaviour
{
    public GameObject interactIconPrefab;
    public RectTransform canvasRectTransform;
    public Transform iconSpawnPos;

    bool isTriggered = false;
    bool gotMap = false;

    GameObject interactIcon;

    private void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame && isTriggered && !gotMap)
        {
            Destroy(interactIcon);
            GameManager.Instance.goMainPlayer.GetComponent<PlayerMapLocation>().unlockMap = true;
            gotMap = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameManager.Instance.goMainPlayer && !isTriggered)
        {
            isTriggered = true;

            Vector3 worldPosition = iconSpawnPos.position;
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

            Vector2 canvasPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPosition, null, out canvasPosition);

            if(interactIcon != null)
            {
                interactIcon.SetActive(true);
            }
            else
            {
                interactIcon = Instantiate(interactIconPrefab, canvasRectTransform);
                interactIcon.GetComponent<RectTransform>().anchoredPosition = canvasPosition;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.Instance.goMainPlayer && isTriggered && !gotMap)
        {
            isTriggered = false;
            interactIcon.SetActive(false);
        }
    }
}
