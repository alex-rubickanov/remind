using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] float moveHorizontal;
    [SerializeField] float speed;
    SpriteRenderer sr;


    Animator animator;

    [SerializeField] VectorValue pastPos;
    [SerializeField] VectorValue roomsPos;

    public bool isAbleToInput = true;

    void Start()
    {
        
        if(SceneManager.GetActiveScene().name == "House")
        {
            transform.position = pastPos.initialValue;
        } else
        {
            transform.position = roomsPos.initialValue;
        }
        
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if(isAbleToInput) 
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");

            if (moveHorizontal == 0f)
            {
                animator.SetBool("isWalking", false);
            }
            else if (moveHorizontal == -1f)
            {
                sr.flipX = true;
                animator.SetBool("isWalking", true);
            }
            else if (moveHorizontal == 1f)
            {
                sr.flipX = false;
                animator.SetBool("isWalking", true);
            }
        }
        



    }
    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(moveHorizontal * speed, 0f);
    }
}
