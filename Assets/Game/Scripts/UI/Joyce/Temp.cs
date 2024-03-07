using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Temp : MonoBehaviour
{
    [SerializeField] InGameMenuUI inGameMenuUI;
    bool isMenuOpened = false;
    private void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            if (!isMenuOpened)
            {
                inGameMenuUI.OpenInGameMenu();
                isMenuOpened = true;
            }
            else
            {
                inGameMenuUI.CloseInGameMenu();
                isMenuOpened = false;
            }
        }
    }

}
