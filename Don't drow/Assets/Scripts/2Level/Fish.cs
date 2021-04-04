using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Character character;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject itembox;
    [SerializeField] private GameObject bred;
    private Vector2 direction;
    private bool isRight;
    private void Start()
    {
        isRight = false;
        sr = GetComponent<SpriteRenderer>();
        direction = Vector2.right * speed;
        rb.velocity = direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            Destroy(collision.gameObject);
            anim.SetTrigger("Attack");
        }
        if (collision.gameObject.tag == "ItemBox")
        {
            Instantiate(bred, itembox.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            anim.SetTrigger("Attack");
        }

        if (collision.gameObject.tag == "Player")
        {
            character.Die();
            anim.SetTrigger("Attack");
        }
        if (isRight)
        {
            rb.velocity = direction;
        }
        else
        {
            rb.velocity = -direction;
        }
        sr.flipX = !sr.flipX;
        isRight = !isRight;
    }
}
