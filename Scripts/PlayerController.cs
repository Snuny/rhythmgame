using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    private Animator animator;
    private Rigidbody2D rb;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Attack1");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Attack2");
        }

        if (Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            grounded = false;
            float jumpVelocity = 6.5f;
            rb.velocity = Vector2.up * jumpVelocity;
            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Hit");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Run");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Platform")
        {
            grounded = true;
        }
    }
}
