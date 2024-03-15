using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public TabletUI tabletUI;

    private void Update()
    {
        if (GameManager.Instance.PlayerInputHandler.ExitPopupInput
            && tabletUI.canExitCanvas)
        {
            GameManager.Instance.PlayerInputHandler.UseExitPopupInput();
            tabletUI.FadeOutGameOverUI();
            gameObject.SetActive(false);
        }
    }
    public void DisplayGameOverUI()
    {
        tabletUI.DisplayGameOverScreen();
    }
}
