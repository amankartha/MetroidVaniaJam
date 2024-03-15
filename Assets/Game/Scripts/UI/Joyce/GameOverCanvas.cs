using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    public GameOverUI panel;

    //event function
    public void DisplayGameOverPanel()
    {
        panel.gameObject.SetActive(true);
        panel.DisplayGameOverUI();
    }
}
