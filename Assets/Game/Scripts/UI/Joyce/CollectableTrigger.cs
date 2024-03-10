using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableTrigger : MonoBehaviour
{
    [SerializeField] Collectable collectable;

    [Header("Bubble Animation")]
    [SerializeField] SpriteRenderer bubbleSpriteRenderer;
    [SerializeField] SpriteRenderer tempBubbleSpriteRenderer;
    [SerializeField] SpriteRenderer objectInsideBubble;
    [SerializeField] List<Sprite> bubbleSprites = new List<Sprite>();

    bool isTriggered = false;
    bool isCollected = false;

    Sequence sequence;

    private void Update()
    {
        if (GameManager.Instance.PlayerInputHandler.InteractInput && isTriggered &&!isCollected)
        {
            isCollected = true;
            GameManager.Instance.PlayerInputHandler.UseInteractInput();
            Debug.Log("passed in id: " + collectable.id);
            GameManager.Instance.OnPlayerCollectable?.Invoke(collectable);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameManager.Instance.goMainPlayer && !isTriggered && !isCollected)
        {
            isTriggered = true;
            ShowBubble();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.Instance.goMainPlayer && isTriggered && !isCollected)
        {
            isTriggered = false;
            sequence.Kill();
            HideBubble();
        }
    }

    void ShowBubble()
    {
        bubbleSpriteRenderer.DOFade(0f, 0f);
        objectInsideBubble.DOFade(0f, 0f);

        tempBubbleSpriteRenderer.sprite = null;
        tempBubbleSpriteRenderer.gameObject.SetActive(true);
        sequence = DOTween.Sequence();
        int counter = 0;

        foreach (Sprite bubbleSprite in bubbleSprites)
        {
            sequence.AppendCallback(() => bubbleSpriteRenderer.sprite = bubbleSprite);
            sequence.Join(bubbleSpriteRenderer.DOFade(0f, 0f)); // Set sprite alpha to 0
            if (counter == bubbleSprites.Count - 1)
            {
                sequence.Append(bubbleSpriteRenderer.DOFade(1f, 0.5f));
                sequence.Join(objectInsideBubble.DOFade(1f, 0.5f));
            }
            else
            {
                sequence.Append(bubbleSpriteRenderer.DOFade(1f, 0.15f));
            }
            sequence.AppendCallback(() => tempBubbleSpriteRenderer.sprite = bubbleSprite);
            counter++;
            if (counter == bubbleSprites.Count)
            {
                sequence.OnComplete(() => tempBubbleSpriteRenderer.gameObject.SetActive(false));
            }
        }
    }


    void HideBubble()
    {
        tempBubbleSpriteRenderer.gameObject.SetActive(false);
        bubbleSpriteRenderer.DOFade(0f, 0.3f);
        objectInsideBubble.DOFade(0f, 0.3f);
    }
}
