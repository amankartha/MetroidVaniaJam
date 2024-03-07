using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AreaMapTrigger : MonoBehaviour
{
    public GameObject interactIconPrefab;
    public Transform iconSpawnPos;

    bool isTriggered = false;
    bool gotMap = false;

    RectTransform canvasRectTransform;
    GameObject interactIcon;
    Vector2 canvasPosition;

    private void Start()
    {
        canvasRectTransform = GameManager.Instance.goHUD.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame && isTriggered && !gotMap)
        {
            GameManager.Instance.mapScript.RevealNewAreaOnMap();
            gotMap = true;
            Destroy(interactIcon);
            Destroy(this.gameObject);
        }

        if (isTriggered && interactIcon != null)
        {
            UpdateCanvasPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameManager.Instance.goMainPlayer && !isTriggered)
        {
            isTriggered = true;

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

    void UpdateCanvasPosition()
    {
        Vector3 worldPosition = iconSpawnPos.position;
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPosition, null, out canvasPosition);
        interactIcon.GetComponent<RectTransform>().anchoredPosition = canvasPosition;
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
