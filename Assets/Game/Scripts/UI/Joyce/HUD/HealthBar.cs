using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthSectionPrefab;
    [SerializeField] GameObject healthBarHolder;
    public GoldenContractDisplay goldenContractDisplay;

    List<Image> healthSections = new List<Image>();

    int healthPerSection;

    void Start()
    {
        for (int i = 0; i < GameManager.Instance.PlayerScript.PlayerHealth.HPSection; i++)
        {
            GameObject section = Instantiate(healthSectionPrefab, healthBarHolder.transform);
            healthSections.Add(section.GetComponent<Image>());
        }
        UpdateHealthBar();
    }


    public void UpgradeHealth()
    {
        
        GameObject section = Instantiate(healthSectionPrefab, healthBarHolder.transform);
        healthSections.Add(section.GetComponent<Image>());
        Image sectionImage = section.GetComponent<Image>();
        Sequence Sequence = DOTween.Sequence();
        for (int i = 0; i < 4; i++)
        {
            Sequence.Append(sectionImage.DOFade(0f, 0.2f));
            Sequence.Append(sectionImage.DOFade(1f, 0.2f));
        }

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthPerSection = GameManager.Instance.PlayerScript.PlayerHealth.HealthPerSection;
        float remainingHealth = GameManager.Instance.PlayerScript.PlayerHealth.HealthValue;
        for (int i = 0; i < GameManager.Instance.PlayerScript.PlayerHealth.HPSection; i++)
        {
            if (remainingHealth >= healthPerSection)
            {
                healthSections[i].fillAmount = 1f;
                remainingHealth -= healthPerSection;
            }
            else if (remainingHealth > 0)
            {
                healthSections[i].fillAmount = (float)remainingHealth / healthPerSection;
                remainingHealth = 0;
            }
            else
            {
                healthSections[i].fillAmount = 0f;
            }
        }
    }
}
