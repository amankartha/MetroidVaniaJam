using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public GameObject quitOptionsHolder;
    public RectTransform noNuttonRect;

    public Button quitButton, noButton, sureButton;

    bool isQuitButtonPressed = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnQuitButton()
    {
        if (!isQuitButtonPressed)
        {
            noButton.interactable = false;
            quitButton.interactable = false;
            quitOptionsHolder.SetActive(true);
            noNuttonRect.DOMoveX(noNuttonRect.position.x + 200f, 0.2f).SetUpdate(true)
                .OnComplete(() => SetButtonsInteractable());
        }
        else
        {
            OnNoButton();
        }
        isQuitButtonPressed = !isQuitButtonPressed;
    }

    public void OnSureButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnNoButton()
    {
        if (isQuitButtonPressed)
        {
            quitButton.interactable = false;
            noButton.interactable = false;
            sureButton.interactable = false;
            noNuttonRect.DOMoveX(noNuttonRect.position.x + -200f, 0.2f).SetUpdate(true)
            .OnComplete(() => DelayNoButton());
        } 
    }

    void DelayNoButton()
    {
        quitOptionsHolder.SetActive(false);
        isQuitButtonPressed = false;
        quitButton.interactable = true;
        sureButton.interactable = true;
    }

    void SetButtonsInteractable()
    {
        quitButton.interactable = true;
        noButton.interactable = true;
    }
}
