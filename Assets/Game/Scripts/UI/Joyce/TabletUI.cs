using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TabletUI : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text mainText;
    [SerializeField] TMP_Text commandText;
    [SerializeField] GameObject displayWithImage;
    [SerializeField] TMP_Text displayWithImageMainText;
    [SerializeField] List<GameObject> images;

    public List<TabletScreen> tabletScreens = new List<TabletScreen>();

    public bool canExitCanvas = false;

    private void OnEnable()
    {
        canExitCanvas = false;
    }

    public void DisplayText(string name)
    {
        TabletScreen tabletScreen = null;
        for (int i = 0; i < tabletScreens.Count; i++)
        {
            if (tabletScreens[i].title == name)
            {
                tabletScreen = tabletScreens[i];
            }
        }
        SetDiaplayText(tabletScreen);
    }
    
    public void SetOneTimeDisplayText(TabletScreen tabletScreen)
    {
        SetDiaplayText(tabletScreen);
    }
    
    void SetDiaplayText(TabletScreen tabletScreen)
    {
        
        if(tabletScreen != null)
        {
            SetCommandLineAlphaToZero();
            titleText.text = tabletScreen.title;
            //commandText.text = tabletScreen.commandText;

            if (tabletScreen.isTextOnly)
            {
                displayWithImage.SetActive(false);
                mainText.gameObject.SetActive(true);
                StartCoroutine(TypeText(tabletScreen.maninTextLines, mainText));
            }
            else
            {
                displayWithImage.SetActive(true);
                mainText.gameObject.SetActive(false);
                for (int i = 0; i < images.Count; i++)
                {
                    if (i < tabletScreen.sprites.Count)
                    {
                        images[i].SetActive(true);
                        images[i].GetComponent<Image>().sprite = tabletScreen.sprites[i];
                    }
                    else
                    {
                        images[i].SetActive(false);
                    }
                }
                StartCoroutine(TypeText(tabletScreen.maninTextLines, displayWithImageMainText));
            }
        }
        else
        {
            Debug.Log("no tabletScreen display called " + name);
        }
        
    }

    void SetCommandLineAlphaToZero()
    {
        Color currentColor = commandText.color;
        currentColor.a = 0f;
        commandText.color = currentColor;
    }

    IEnumerator TypeText(string[] lines, TMP_Text mainTextTMP)
    {
        string previousText = "";
        foreach (string line in lines)
        {
            for (int i = 0; i <= line.Length; i++)
            {
                mainTextTMP.text = previousText + line.Substring(0, i);
                yield return new WaitForSecondsRealtime(0.03f);
            }
            yield return new WaitForSecondsRealtime(0.65f);
            //gameOverText.text += "\n";
            previousText = mainTextTMP.text + "\n";
        }

        FadeInText(commandText);
    }

    void FadeInText(TMP_Text text)
    {
        text.DOFade(1f, 0.8f).SetEase(Ease.Linear).SetUpdate(true)
            .OnComplete(() => canExitCanvas = true);
    }

    public void FadeInCanvas()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.DOFade(1f, 0.8f).SetUpdate(true);
    }

    public void FadeOutAndDestroyCanvas()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.DOFade(0f, 0.4f).SetUpdate(true)
            .OnComplete(() => Destroy(this.gameObject));
    }

    public void DisplayGameOverScreen()
    {
        FadeInCanvas();
        SetDiaplayText(tabletScreens[0]);
    }
}
