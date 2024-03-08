using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenContractDisplay : MonoBehaviour
{
    public List<Sprite> contractFragment = new List<Sprite>();
    [SerializeField] Image displayImage;

    private void OnEnable()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        int fragments = GameManager.Instance.PlayerScript.PlayerHealth.GoldenContractFragment;
        displayImage.sprite = contractFragment[fragments];
    }
}
