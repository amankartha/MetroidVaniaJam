using System.Collections;
using System.Collections.Generic;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public SceneReference sMainGame;

    #region METHODS

    public void LoadScene()
    {
        UTIL.LoadScene(sMainGame);
    }
    

    #endregion
}
