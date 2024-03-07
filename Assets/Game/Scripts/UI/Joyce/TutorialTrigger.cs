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
    [SerializeField] Key exitCanvasKey = Key.E;

    bool isTriggered = false;

    private void Update()
    {
        if (Keyboard.current[exitCanvasKey].wasPressedThisFrame
            && tabletUI.canExitCanvas
            && isTriggered )
        {
            GameManager.Instance.goMainPlayer.GetComponent<PlayerInput>().ActivateInput();
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
            collision.gameObject.GetComponent<PlayerInput>().DeactivateInput();
            Time.timeScale = 0;
            GameObject go = Instantiate(tabletCanvasPrefab);
            tabletUI = go.GetComponent<TabletUI>();
            tabletUI.FadeInCanvas();
            tabletUI.SetOneTimeDisplayText(tabletScreen);
        }
    }
}
