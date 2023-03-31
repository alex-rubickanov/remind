using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utils
{
    public static void ShowJumpscare()
    {
        SceneManager.LoadScene(6);
    }

    public static void HideJumpscare(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
