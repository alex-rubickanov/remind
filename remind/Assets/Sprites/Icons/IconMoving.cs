using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMoving : MonoBehaviour
{

    [SerializeField] float amp = 0.0001f;
    [SerializeField] float freq = 6f;
    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin((transform.position.y + Time.time) * freq) * amp, transform.position.z);
    }
}
