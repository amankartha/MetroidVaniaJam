using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject tabletCanvasPrefab;
    TabletUI tabletUI;
    [SerializeField] TabletScreen tabletScreen;

    bool isTriggered = false;

    private void Update()
    {
        if (GameManager.Instance.PlayerInputHandler.ExitPopupInput
            && tabletUI.canExitCanvas
            && isTriggered )
        {
            GameManager.Instance.PlayerInputHandler.UseExitPopupInput();
            Time.timeScale = 1;
            tabletUI.FadeOutAndDestroyCanvas();
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.Instance.goMainPlayer && !isTriggered)
        {
            isTriggered = true;
            Time.timeScale = 0;
            GameObject go = Instantiate(tabletCanvasPrefab);
            tabletUI = go.GetComponent<TabletUI>();
            tabletUI.FadeInCanvas();
            tabletUI.SetOneTimeDisplayText(tabletScreen);
        }
    }
}
