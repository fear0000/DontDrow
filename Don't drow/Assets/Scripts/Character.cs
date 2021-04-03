using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator eAnim;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator bubbleAnim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumperForce;
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
            Jump(jumpForce);
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


        //РЕСЕТ СОХРАНЕНИЙ УБРАТЬ КОГДА НАДО
        if (Input.GetKey(KeyCode.M))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Govna")
            Die();
        if(collision.gameObject.tag == "Jumper")
        {
            Jump(jumperForce);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Usable")
    //    {
    //        eAnim.SetTrigger("Open");
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Usable")
    //    {
    //        eAnim.SetTrigger("Close");
    //    }
    //}
    public void Die()
    {
        anim.SetTrigger("Die");
        bubbleAnim.SetTrigger("Die");
        StartCoroutine(RestartScene());
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Usable")
    //    {
    //        eAnim.SetTrigger("Open");
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Usable")
    //    {
    //        eAnim.SetTrigger("Close");
    //    }
    //}

    private void Flip()
    {
        isRight = !isRight;
        gameObject.transform.Rotate(0, 180, 0);
    }

    private void Jump(float jumpF)
    {
        anim.SetTrigger("Jump");
        rb.AddForce(new Vector2(0, jumpF));
    }

}
