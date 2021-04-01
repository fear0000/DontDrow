using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{ 
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private bool isRight = true;
    private bool isGrounded = true;
    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0 && !isRight)
            Flip();
        else if (Input.GetAxis("Horizontal") < 0 && isRight)
            Flip();

        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isRun", true);
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed , rb.velocity.y);
        }
        else
        {
            anim.SetBool("isRun", false);
            rb.velocity = new Vector2(0 , rb.velocity.y);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            anim.SetBool("isGrounded", true);
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }
    }

    private void Flip()
    {
        isRight = !isRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
