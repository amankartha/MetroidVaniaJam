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

    GameObject player;

    private void Update()
    {
        if (Keyboard.current[exitCanvasKey].wasPressedThisFrame
            && tabletUI.canExitCanvas
            && isTriggered )
        {
            player.GetComponent<PlayerInput>().ActivateInput();
            tabletUI.FadeOutAndDestroyCanvas();
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            player = collision.gameObject;
            collision.GetComponent<PlayerInput>().DeactivateInput();
            GameObject go = Instantiate(tabletCanvasPrefab);
            tabletUI = go.GetComponent<TabletUI>();
            tabletUI.FadeInCanvas();
            tabletUI.SetOneTimeDisplayText(tabletScreen);
        }
    }
}
