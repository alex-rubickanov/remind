using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{
    Vector3 Mouseposition;

    public Vector3 MouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        Mouseposition = gameObject.transform.position - MouseWorldPosition();
    }

    private void OnMouseDrag() 
    {
        transform.position = MouseWorldPosition()+ Mouseposition;
    }

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
