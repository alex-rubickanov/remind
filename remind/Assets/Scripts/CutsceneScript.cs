using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneScript : MonoBehaviour
{
    [Header("Animation Contoller")]
    [SerializeField] CanvasGroup[] canvasGroups;
    [SerializeField] AnimationCurve curve;
    [SerializeField] Animator secondFrameAnimator;
    [SerializeField] Animator familyPicAnimator;
    [SerializeField] Animator fadeInAnimator;
    [SerializeField] GameObject fadeInObject;

    int frame = 1;
    [Header("Skip Slider")]
    [SerializeField] Slider slider;
    [SerializeField] GameObject skipCanvas;
    [SerializeField] GameObject skipText;

    private void Start()
    {
        
        AlphaIncrease(canvasGroups[0]);
    }

    private void Update()
    {
        SkipButton();
    }

    IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        float f = 0f;

        while (f < 1f)
        {
            f += Time.deltaTime * 1f;
            float a = curve.Evaluate(f);
            canvasGroup.alpha = a;
            yield return null;
        }
    }

    IEnumerator FadeOut(CanvasGroup canvasGroup) //as a previous coroutine we make a fade to make our text/image appeear
    {
        float f = 1f;

        while (f > 0f)
        {
            f -= Time.deltaTime * 1f;
            float a = curve.Evaluate(f);
            canvasGroup.alpha = a;
            yield return null;
        }
    }

    void AlphaReduce(CanvasGroup canvasGroup)   
    {
        StartCoroutine(FadeOut(canvasGroup));
    }

    void AlphaIncrease(CanvasGroup canvasGroup)
    {
        StartCoroutine(FadeIn(canvasGroup));    
    }


     

    public void ButtonClick()           //every click we get next case
    {
        switch (frame)
        {
            case 1:
                AlphaIncrease(canvasGroups[1]);
                break;
            case 2:
                AlphaReduce(canvasGroups[2]);
                AlphaIncrease(canvasGroups[3]);
                break;
            case 3:
                AlphaIncrease(canvasGroups[4]);
                break;
            case 4:
                secondFrameAnimator.SetTrigger("MariaZoom");
                AlphaReduce(canvasGroups[5]);
                AlphaIncrease(canvasGroups[6]);
                break;
            case 5:
                AlphaReduce(canvasGroups[6]);
                AlphaIncrease(canvasGroups[7]);
                break;
            case 6:
                AlphaReduce(canvasGroups[7]);
                AlphaIncrease(canvasGroups[8]);
                break;
            case 7:
                AlphaReduce(canvasGroups[8]);
                secondFrameAnimator.SetTrigger("MariaBackZoom");
                break;
            case 8:
                secondFrameAnimator.SetTrigger("MateoZoom");
                AlphaIncrease(canvasGroups[9]);
                break;
            case 9:
                AlphaReduce(canvasGroups[9]);
                AlphaIncrease(canvasGroups[10]);
                break;
            case 10:
                AlphaReduce(canvasGroups[10]);
                AlphaIncrease(canvasGroups[11]);
                break;
            case 11:
                secondFrameAnimator.SetTrigger("MateoBackZoom");
                AlphaReduce(canvasGroups[11]);
                break;
            case 12:
                AlphaIncrease(canvasGroups[12]);
                break;
            case 13:
                AlphaReduce(canvasGroups[13]);
                AlphaIncrease(canvasGroups[14]);
                break;
            case 14:
                AlphaReduce(canvasGroups[14]);
                AlphaIncrease(canvasGroups[15]);
                break;
            case 15:
                AlphaReduce(canvasGroups[15]);
                AlphaIncrease(canvasGroups[16]);
                break;
            case 16:
                AlphaReduce(canvasGroups[16]);
                AlphaIncrease(canvasGroups[17]);
                break;
            case 17:
                AlphaIncrease(canvasGroups[18]);
                familyPicAnimator.SetTrigger("AnimTrigger");
                break;
            case 18:
                AlphaReduce(canvasGroups[19]);
                AlphaIncrease(canvasGroups[20]);
                break;
            case 19:
                AlphaReduce(canvasGroups[20]);
                AlphaIncrease(canvasGroups[21]);
                break;
            case 20:
                AlphaReduce(canvasGroups[21]);
                break;
            case 21:
                fadeInObject.SetActive(true);
                StartCoroutine(ThreeSecondsTimer());
                
                break;




        }

        frame++;

       
    }

    IEnumerator ThreeSecondsTimer()
    {
        fadeInAnimator.SetTrigger("Fade");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }


    private void SkipButton()   
    {
        Debug.Log(slider.value);

        if(Input.GetKey(KeyCode.F))
        {
            skipCanvas.SetActive(true);
            slider.value += Time.deltaTime;
            skipText.SetActive(false);
        }
        if (slider.value < slider.maxValue)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                skipCanvas.SetActive(false);
                slider.value = 0;
                
            }
        }
        

        if(slider.value >= slider.maxValue)
        {
            fadeInObject.SetActive(true);
            StartCoroutine(ThreeSecondsTimer());
        }
    }
}
