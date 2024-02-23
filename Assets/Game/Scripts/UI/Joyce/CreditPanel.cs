using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditPanel : MonoBehaviour
{
    [SerializeField] private Button _filpBackButton;

    public void TurnOnFlipBackButton()
    {
        _filpBackButton.interactable = true;
    }
}
