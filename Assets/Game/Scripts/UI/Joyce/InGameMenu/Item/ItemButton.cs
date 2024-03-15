using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour
{
    public Image discriptionImage;
    public TMP_Text discriptionText;

    [SerializeField] TMP_Text titleText;
    [SerializeField] Collectable collectable;

    [SerializeField] GameObject newIndicator;

    public void OnButtonClick()
    {
        discriptionImage.sprite = collectable.sprite;
        discriptionText.text = collectable.content;
        gameObject.GetComponent<Button>().Select();
    }
    public void OnButtonHover()
    {
        if (!discriptionImage.enabled)
        {
            discriptionImage.enabled = true;
        }
        discriptionImage.sprite = collectable.sprite;
        discriptionText.text = collectable.content;
        gameObject.GetComponent<Button>().Select();
        newIndicator.SetActive(false);
    }

    public void OnButtonExit()
    {
       /* if (!isSelected)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }*/
    }

    public void SetUIDisplay(Image image, TMP_Text text)
    {
        discriptionImage = image;
        discriptionText = text;
        titleText.text = collectable.title;
    }
}
