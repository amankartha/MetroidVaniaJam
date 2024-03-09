using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GoldenContractDisplay : MonoBehaviour
{
    [SerializeField] List<Sprite> contractFragment = new List<Sprite>(); 
    [SerializeField] Image displayImage;
    [SerializeField] Image tempDisplayImage;

    private void OnEnable()
    {
        UpdateDisplay();
    }


    public void UpdateDisplay()
    {
        //DisableImages();

        int fragments = GameManager.Instance.PlayerScript.PlayerHealth.GoldenContractFragment % 3;
        displayImage.sprite = contractFragment[fragments];

        Sequence sequence = DOTween.Sequence();
        sequence.Append(tempDisplayImage.DOFade(1f, 0.5f));
        sequence.Append(displayImage.DOFade(1f, 0.5f));
        sequence.AppendCallback(() => tempDisplayImage.sprite = displayImage.sprite);
    }

    public void ClosePanel()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(displayImage.DOFade(0f, 0.4f));
        sequence.Join(tempDisplayImage.DOFade(0f, 0.4f));
        sequence.AppendCallback(() => this.gameObject.SetActive(false));
    }


}
