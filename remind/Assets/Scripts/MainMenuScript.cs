using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] Animator animator;

    public void PlayButton()
    {
        animator.SetTrigger("FadeOut");
        
    }

    public void OptionsButton() 
    { 
       
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void FadeInEvent()
    {
        SceneManager.LoadScene(1);
    }
}
