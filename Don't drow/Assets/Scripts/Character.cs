using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{ 
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float groundRadius;
    private bool isRight = true;
    private bool isGrounded = true;
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("isGrounded", isGrounded);

        if (Input.GetAxisRaw("Jump") > 0 && isGrounded)
        {
            Jump();
            isGrounded = false;
        }

        if (Input.GetAxisRaw("Horizontal") > 0 && !isRight)
            Flip();
        else if (Input.GetAxisRaw("Horizontal") < 0 && isRight)
            Flip();

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetBool("isRun", true);
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed , rb.velocity.y);
        }
        else
        {
            anim.SetBool("isRun", false);
            rb.velocity = new Vector2(0 , rb.velocity.y);
        }

        
            
    }

    private void Flip()
    {
        isRight = !isRight;
        gameObject.transform.Rotate(0, 180, 0);
    }

    private void Jump()
    {
        anim.SetTrigger("Jump");
        rb.AddForce(new Vector2(0, jumpForce));
    }
}
