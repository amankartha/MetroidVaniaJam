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

    public void OnButtonHover()
    {
        discriptionImage.sprite = spriteToDisplay;
        discriptionText.text = textToDisplay;
    }

    public void OnButtonExit()
    {
        discriptionImage.sprite = null;
        discriptionText.text = "";
    }

}
