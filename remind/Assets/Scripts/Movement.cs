using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb2D;
    float moveHorizontal;
    [SerializeField] float speed = 1f;
    SpriteRenderer sr; 

    Animator animator;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (moveHorizontal == 0f)
        {
            animator.SetBool("isWalking", false);
        } else if (moveHorizontal == -1f)
        {
            sr.flipX = true;
            animator.SetBool("isWalking", true);
        } else
        {
            sr.flipX = false;
            animator.SetBool("isWalking", true);
        }

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(3);
        }
        
    }
    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(moveHorizontal * speed, 0f);
    }

}
