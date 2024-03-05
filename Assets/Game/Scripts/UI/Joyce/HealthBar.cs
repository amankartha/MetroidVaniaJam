using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthSectionPrefab;
    [SerializeField] GameObject healthBarHolder;
    List<Image> healthSections = new List<Image>();

    public int maxHealth = 100;
    public int currentHealth = 100;
    public int healthPerSection;
    public int numSections = 5;

    void Start()
    {
        healthPerSection = maxHealth / numSections;

        for (int i = 0; i < numSections; i++)
        {
            GameObject section = Instantiate(healthSectionPrefab, healthBarHolder.transform);
            healthSections.Add(section.GetComponent<Image>());
        }
        UpdateHealthBar();
    }

    private void Update()
    {
        //for testing
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UpgradeHealth();
        }

        UpdateHealthBar();*/
    }

    public void UpgradeHealth()
    {
        numSections++;
        GameObject section = Instantiate(healthSectionPrefab, healthBarHolder.transform);
        healthSections.Add(section.GetComponent<Image>());
        
        maxHealth += healthPerSection;
        currentHealth = maxHealth;

        UpdateHealthBar();

    }

    void UpdateHealthBar()
    {
        float remainingHealth = currentHealth;
        for (int i = 0; i < numSections; i++)
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
