using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2D;

    [SerializeField] public float speed = 1f;
    private float movehorizontal;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        movehorizontal = Input.GetAxisRaw("Horizontal");

       
       
    }

    void FixedUpdate()
    {
            rb2D.velocity = new Vector2(movehorizontal * speed, 0f);
    }
}
