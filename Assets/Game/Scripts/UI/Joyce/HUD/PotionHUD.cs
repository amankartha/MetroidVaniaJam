using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionHUD : MonoBehaviour
{
    public TMP_Text potionText;
    [SerializeField] Image potionFillImage;

    void Start()
    {
        UpdatePotionHUD();
    }

    public void UpdatePotionHUD()
    {
        int currentPotions = GameManager.Instance.PlayerScript.PotionCount;
        int maxPotions = GameManager.Instance.PlayerScript.MaxPotions;
        potionText.text = currentPotions + "/" + maxPotions;

        if (currentPotions >= maxPotions)
        {
            potionFillImage.fillAmount = 1f;
        }
        else if (currentPotions <= 0)
        {
            potionFillImage.fillAmount = 0f;
        }
        else
        {
            potionFillImage.fillAmount = (float)currentPotions / maxPotions;
        }
    }
}
