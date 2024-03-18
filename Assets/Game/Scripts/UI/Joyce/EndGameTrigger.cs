using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    public GameObject endGameCanvas;
    public Image BGImage;
    public CanvasGroup TextHolderCanvasGroup;

    bool isTriggered = false;
    bool canReturn = false;

    private void Update()
    {
        if (isTriggered && canReturn && GameManager.Instance.PlayerInputHandler.ExitPopupInput)
        {
            GameManager.Instance.PlayerInputHandler.UseExitPopupInput();
            RetrunToMainMenu();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameManager.Instance.goMainPlayer && !isTriggered)
        {
            isTriggered = true;
            Time.timeScale = 0f;
            endGameCanvas.SetActive(true);

            Sequence sequence = DOTween.Sequence();

            sequence.Append(BGImage.DOFade(1, 0.5f).SetUpdate(true));
            sequence.AppendInterval(2f).SetUpdate(true);
            sequence.Append(TextHolderCanvasGroup.DOFade(1, 0.3f).SetUpdate(true)
                .OnComplete(() => canReturn = true));           
        }
    }

    void RetrunToMainMenu()
    {
        Time.timeScale = 1f;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene loadedScene = SceneManager.GetSceneAt(i);
            if (loadedScene.isLoaded)
            {
                SceneManager.UnloadSceneAsync(loadedScene);
            }
        }
        SceneManager.LoadScene(0);
    }
}
