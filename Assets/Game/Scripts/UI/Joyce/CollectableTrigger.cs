using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTrigger : MonoBehaviour
{
    [SerializeField] Collectable collectable;

    bool isTriggered = false;
    bool isCollected = false;

    public ItemDisplay itemDisplay;

    private void Start()
    {
        itemDisplay = GameManager.Instance.goInGameMenu.GetComponent<ItemDisplay>();
    }
    private void Update()
    {
        if (GameManager.Instance.PlayerInputHandler.InteractInput && isTriggered &&!isCollected)
        {
            isCollected = true;
            GameManager.Instance.PlayerInputHandler.UseInteractInput();
            Debug.Log("passed in id: " + collectable.id);
            GameManager.Instance.OnPlayerCollectable?.Invoke(collectable);

            //itemDisplay.myEvent.Invoke(collectable);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameManager.Instance.goMainPlayer && !isTriggered && !isCollected)
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.Instance.goMainPlayer && isTriggered && !isCollected)
        {
            isTriggered = false;
        }
    }
}
