using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;


public class CreditPanel : MonoBehaviour
{
    [SerializeField] private Button _filpBackButton;

    public MMPositionShaker shaker;

    /*private void Start()
    {
        shaker.Play();
    }*/
    public void TurnOnFlipBackButton()
    {
        _filpBackButton.interactable = true;
    }
}
