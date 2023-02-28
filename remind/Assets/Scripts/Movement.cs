using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float movehorizontal;
    [SerializeField] float speed = 1f;
    void Start()
    {
        rb2D =GetComponent<Rigidbody2D>();
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
