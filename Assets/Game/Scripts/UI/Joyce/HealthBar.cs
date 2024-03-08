using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthSectionPrefab;
    [SerializeField] GameObject healthBarHolder;
    List<Image> healthSections = new List<Image>();

    //int maxHealth;
    //int currentHealth;
    int healthPerSection;
    //int numSections;

    void Start()
    {
        //maxHealth = GameManager.Instance.PlayerScript.PlayerHealth.MaxHealth;
        //currentHealth = GameManager.Instance.PlayerScript.PlayerHealth.HealthValue;
        //numSections = GameManager.Instance.PlayerScript.PlayerHealth.HPSection;
        healthPerSection = GameManager.Instance.PlayerScript.PlayerHealth.HealthPerSection;

        for (int i = 0; i < GameManager.Instance.PlayerScript.PlayerHealth.HPSection; i++)
        {
            GameObject section = Instantiate(healthSectionPrefab, healthBarHolder.transform);
            healthSections.Add(section.GetComponent<Image>());
        }
        UpdateHealthBar();
    }


    public void UpgradeHealth()
    {
        //numSections++;
        GameObject section = Instantiate(healthSectionPrefab, healthBarHolder.transform);
        healthSections.Add(section.GetComponent<Image>());
        
        //maxHealth += healthPerSection;
        //currentHealth = maxHealth;

        UpdateHealthBar();

    }

    void UpdateHealthBar()
    {
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
