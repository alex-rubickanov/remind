using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsReminder : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;

    private void Start()
    {
        Invoke("Fade", 3f);
    }

    public IEnumerator FadeOut(CanvasGroup canvasGroup) //as a previous coroutine we make a fade to make our text/image appeear
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

    private void Fade()
    {
        StartCoroutine(FadeOut(gameObject.GetComponent<CanvasGroup>()));
    }
}
