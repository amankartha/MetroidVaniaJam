using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using DG.Tweening;


public class CollectableBubble : MonoBehaviour
{
    [SerializeField] SpriteRenderer bullbeSpriteRenderer, tempBullbeSpriteRenderer;
    [SerializeField] SpriteRenderer objectInsideBubble;
    [SerializeField] List<Sprite> bubbleSprites = new List<Sprite>();

    bool isTriggered = false;
    bool isCollected = false;

    private void Update()
    {
        if (GameManager.Instance.PlayerInputHandler.InteractInput && isTriggered && !isCollected)
        {
            GameManager.Instance.PlayerInputHandler.UseInteractInput();
            isCollected = true;
            bool shouldUpdateUI = GameManager.Instance.PlayerScript.PlayerHealth.CollcetGoldenContract();
            if (shouldUpdateUI)
            {
                GameManager.Instance.PlayerScript.UpdateHealthBarUI();
            }
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameManager.Instance.goMainPlayer && !isTriggered)
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
            HideBubble();
        }
    }

    void ShowBubble()
    {
        tempBullbeSpriteRenderer.sprite = null;
        tempBullbeSpriteRenderer.gameObject.SetActive(true);

        Sequence sequence = DOTween.Sequence();
        int counter = 0;

        foreach (Sprite bubbleSprite in bubbleSprites)
        {
            sequence.AppendCallback(() => bullbeSpriteRenderer.sprite = bubbleSprite);
            sequence.Join(bullbeSpriteRenderer.DOFade(0f, 0f)); // Set sprite alpha to 0
            if(counter == bubbleSprites.Count - 1)
            {
                sequence.Append(bullbeSpriteRenderer.DOFade(1f, 0.5f));
                sequence.Join(objectInsideBubble.DOFade(1f, 0.5f));
            }
            else
            {
                sequence.Append(bullbeSpriteRenderer.DOFade(1f, 0.15f));
            }
            sequence.AppendCallback(() => tempBullbeSpriteRenderer.sprite = bubbleSprite);
            //sequence.AppendInterval(0.06f);
            counter++;
            if (counter == bubbleSprites.Count)
            {
                sequence.OnComplete(() => tempBullbeSpriteRenderer.gameObject.SetActive(false));
            }
        }
    }


    void HideBubble()
    {
        bullbeSpriteRenderer.DOFade(0f, 0.4f);
        objectInsideBubble.DOFade(0f, 0.4f);
    }
}
