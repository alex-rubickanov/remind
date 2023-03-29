using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueClothes : MonoBehaviour
{
    private IEnumerator SmoothLerp(float time)
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = transform.position + (transform.right * 4);
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void ClothAnimation()
    {
        StartCoroutine(SmoothLerp(1f));
    }
}
