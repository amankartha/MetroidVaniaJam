using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterPanelButtons : MonoBehaviour
{
    [SerializeField] Image discriptionImage;
    [SerializeField] TMP_Text discriptionText;
    [SerializeField] Sprite spriteToDisplay;
    [SerializeField] string textToDisplay;
    [SerializeField] Image buttonImage;
    public Color32 buttonHoverColour;
    Color32 originalButtonColour;

    private void Start()
    {
        originalButtonColour = buttonImage.color;
    }

    public void OnButtonHover()
    {
        discriptionImage.sprite = spriteToDisplay;
        discriptionImage.enabled = true;
        discriptionText.text = textToDisplay;
        buttonImage.color = buttonHoverColour;
    }

    public void OnButtonExit()
    {
        discriptionImage.enabled = false;
        discriptionText.text = "";
        buttonImage.color = originalButtonColour;
    }

}
