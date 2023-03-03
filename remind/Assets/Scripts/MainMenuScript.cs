using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject optionsCanvas;

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsButton() 
    { 
        optionsCanvas.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
