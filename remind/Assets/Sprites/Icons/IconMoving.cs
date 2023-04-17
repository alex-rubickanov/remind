using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMoving : MonoBehaviour
{

     float amp = 0.2f;
    [SerializeField] float freq = 6f;
    Vector3 initPos;

    private void Start()
    {
        initPos= transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, 0);
    }
}
