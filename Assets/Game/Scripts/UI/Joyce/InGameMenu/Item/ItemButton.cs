using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{
    public Image discriptionImage;
    public TMP_Text discriptionText;

    [SerializeField] Collectable collectable;

    public void OnButtonHover()
    {
        discriptionImage.sprite = collectable.sprite;
        discriptionText.text = collectable.content;
    }

    /*public void OnButtonExit()
    {
        discriptionImage.sprite = null;
        discriptionText.text = "";
    }*/

    public void SetUIDisplay(Image image, TMP_Text text)
    {
        discriptionImage = image;
        discriptionText = text;
    }
}
