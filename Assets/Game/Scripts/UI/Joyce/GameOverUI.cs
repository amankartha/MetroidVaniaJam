using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] GameObject restartTextGO;
    [SerializeField] TMP_Text restartText;
    public string[] gameOverLines;

    private void OnEnable()
    {
        Color currentColor = restartText.color;
        currentColor.a = 0f;
        restartText.color = currentColor;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        string previousText = "";
        foreach (string line in gameOverLines)
        {
            for (int i = 0; i <= line.Length; i++)
            {
                gameOverText.text = previousText + line.Substring(0, i);
                yield return new WaitForSeconds(0.03f);
            }
            yield return new WaitForSeconds(0.65f);
            //gameOverText.text += "\n";
            previousText = gameOverText.text + "\n";
        }

        FadeInText(restartText);
    }

    void FadeInText(TMP_Text text)
    {
        text.DOFade(1f, 0.8f).SetEase(Ease.Linear);
    }
}
