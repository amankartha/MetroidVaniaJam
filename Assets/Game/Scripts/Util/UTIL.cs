using System.Collections;
using System.Collections.Generic;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class UTIL 
{
    public static void LoadScene(SceneReference sceneReference)
    {
        SceneManager.LoadScene(sceneReference.BuildIndex);
    }
}
